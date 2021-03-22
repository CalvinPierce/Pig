using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pig.Models
{
    public class GameSession
    {
        private const string gameKey = "piggame";
        private ISession session;

        public GameSession(ISession sess) => session = sess;
        public Game GetGame() => session.GetObject<Game>(gameKey) ?? new Game();
        public void SetGame(Game game) => session.SetObject(gameKey, game);
    }
}
