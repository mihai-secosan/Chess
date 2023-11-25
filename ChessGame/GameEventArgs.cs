using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class GameEventArgs : EventArgs
    {
        public GameContext Context { get; set; }
    }
}
