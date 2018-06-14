using Autofac;
using FluentAssertions;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TurtleGame.Domain.Condition.Factories;
using TurtleGame.Domain.Factories;
using TurtleGame.Domain.Factories.Interfaces;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player.Types;
using TurtleGame.Domain.Player.Types.BetCards;
using TurtleGame.Domain.Player.Types.UserNotificationsDelegates;
using TurtleGame.Domain.Racing;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Factories;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.Domain.RacingCards.Managers;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Tracks;
using TurtleGame.Domain.Tracks.Factories;
using TurtleGame.Domain.Tracks.Strategies;
using TurtleGame.SharedKernel.Strategies;
using Xunit;

namespace TurtleGame.Domain.Integration.Tests
{
    public class BoardGameShould
    {
        private BoardGame _sut;
        private readonly IRacingCardManager _racingCardManager;
        private readonly IBoardGameFactory _boardGameFactory;
        private readonly RegularPlayer _playerOne;
        private readonly RegularPlayer _playerTwo;
        private RegularPlayer _playerThree;
        private IRacingCardsFactory _racingCardsFactory = new RacingCardsFactory();
        private IRacingCardOnDeskManager _racingCardOnDeskManager = new RacingCardOnDeskManager();
        public BoardGameShould()
        {

            _racingCardManager = new RacingCardManager(_racingCardsFactory,
                                                       new RandomMixStrategy(),
                                                       _racingCardOnDeskManager);

            _boardGameFactory = new BoardGameFactory(new PlayersManagerFactory(new RandomMixStrategy(),
                                                                               _racingCardManager),
                                                                               _racingCardOnDeskManager);
            _playerOne = CreateUser();
            _playerTwo = CreateUser();
            _sut = _boardGameFactory.ToTwoPlayer(_playerOne, _playerTwo);
        }

        private RegularPlayer CreateUser()
        {
            var random = new Random();
            return new RegularPlayer(UserCallbacksNotifications.Create(track => new SideBoderSelected(track,
                                                                                                        new SideOfTrackDown(),
                                                                                                        new LineBorderTrack()),
                                                                        x => x.ToList().First(),
                                                                        x => RacingCards.RacingCards.Create(new List<IRacingCard> { x.ToList().First() })),
                                    BetCardsPlayerManager.Create(),
                                   _racingCardManager,
                                    new PreConditionRaicingCardsFactory().Create());
        }

        [Fact]
        public void Start_Game_With_Two_Players()
        {
            _sut.Start();

            _sut.Players.NumberOfPlayers.Should().Be(2);
            _playerOne.BetCardsQuantity.Should().Be(3);
            _playerTwo.MyRacingCards.Count().Should().Be(6);
            _playerOne.MyRacingCards.Count().Should().Be(6);
        }

        [Fact]
        public void Start_Game_With_Three_Players()
        {
            _playerThree = CreateUser();
            _sut = _boardGameFactory.ToThreePlayer(_playerOne, _playerTwo, _playerThree);
            _sut.Start();

            _sut.Players.NumberOfPlayers.Should().Be(3);
            _playerOne.BetCardsQuantity.Should().Be(2);
            _playerOne.MyRacingCards.Count().Should().Be(6);
            _playerTwo.MyRacingCards.Count().Should().Be(6);
            _playerThree.MyRacingCards.Count().Should().Be(6);
        }

        [Fact]
        public async Task MediatRAsync()
        {
            //TODO: Refactor this implementation of Static Property
            BoardGame.Mediator = BuildMediator();

            _playerThree = CreateUser();
            _sut = _boardGameFactory.ToThreePlayer(_playerOne, _playerTwo, _playerThree);

            ITrackManager trackManager = new TrackManager(new TracksFactory(), new DecideSideFactory());
            _sut.Start();
            new RacingManager(_racingCardOnDeskManager,
                              trackManager).StartRace();

            _sut.Players.NumberOfPlayers.Should().Be(3);
            _playerOne.BetCardsQuantity.Should().Be(2);
            _playerOne.MyRacingCards.Count().Should().Be(6);
            _playerTwo.MyRacingCards.Count().Should().Be(6);
            _playerThree.MyRacingCards.Count().Should().Be(6);
        }

        private IMediator BuildMediator()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(INotificationHandler<>),
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(typeof(BoardGame).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }

            //builder.RegisterInstance(writer).As<TextWriter>();

            // It appears Autofac returns the last registered types first
            builder.RegisterGeneric(typeof(RequestPostProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            //builder.RegisterGeneric(typeof(GenericRequestPreProcessor<>)).As(typeof(IRequestPreProcessor<>));
            //builder.RegisterGeneric(typeof(GenericRequestPostProcessor<,>)).As(typeof(IRequestPostProcessor<,>));
            //builder.RegisterGeneric(typeof(GenericPipelineBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            //builder.RegisterGeneric(typeof(ConstrainedRequestPostProcessor<,>)).As(typeof(IRequestPostProcessor<,>));
            //builder.RegisterGeneric(typeof(ConstrainedPingedHandler<>)).As(typeof(INotificationHandler<>));

            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            var container = builder.Build();

            // The below returns:
            //  - RequestPreProcessorBehavior
            //  - RequestPostProcessorBehavior
            //  - GenericPipelineBehavior

            //var behaviors = container
            //    .Resolve<IEnumerable<IPipelineBehavior<Ping, Pong>>>()
            //    .ToList();

            var mediator = container.Resolve<IMediator>();

            return mediator;
        }
    }    
}
