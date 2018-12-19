using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sokoban
{
    class Level
    {
        bool AllBoxInParking = true;

        public Map map;
        public Player player;
        public Painter painter;
        private float elapsedTime;

        KeyboardState currentKeyboardState;


        public void Initialize(List<String> mapTemplate, List<Position> boxPosition, Position startPosition)
        {
            // TODO: Add your initialization logic here
            map = new Map();

            map.Create(mapTemplate);
            player = map.GetPlayer(startPosition.X,startPosition.Y);

            map.Boxes = boxPosition.Select(pos => new Box(pos.X, pos.Y, map[pos.X, pos.Y])).ToList();
            painter = new Painter((int)Game1.WindowSize.X, (int)Game1.WindowSize.Y, map.Height, map.Width);
        }



        public void Update(GameTime gameTime)
        {
            
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsedTime > 100)
            {
                currentKeyboardState = Keyboard.GetState();
                var delta = GetDelta();
                IMapElement newPosPlayer = map[player.Position.X + delta.X, player.Position.Y + delta.Y];

                if ((delta.X!=0 || delta.Y!=0) && newPosPlayer.CanCome())
                {
                    player.Position = newPosPlayer.GetPosition();
                    player.moves++;
                }
                else
                    if (newPosPlayer.GetBox() != null)
                {
                    Position newPositionBox = new Position(player.Position.X + delta.X * 2, player.Position.Y + delta.Y * 2);
                    if (map.CorectPosition(newPositionBox) && map[newPositionBox.X, newPositionBox.Y].CanCome())
                    {
                        IMapElement newPosBox = map[newPositionBox.X, newPositionBox.Y];
                        player.Position = newPosPlayer.GetPosition();

                        Box box = newPosPlayer.GetBox();
                        newPosPlayer.SetBox(null);
                        newPosBox.SetBox(box);
                        box.Position = newPosBox.GetPosition();
                        box.InParking = newPosBox is BoxParking;
                        player.moves++;
                        player.pushes++;
                    }
                }


                elapsedTime = 0;
            }
        }

        private Position GetDelta()
        {
            if (currentKeyboardState.IsKeyDown(Keys.Up))
                return new Position(-1, 0);
            if (currentKeyboardState.IsKeyDown(Keys.Down))
                return new Position(1, 0);
            if (currentKeyboardState.IsKeyDown(Keys.Left))
                return new Position(0, -1);
            if (currentKeyboardState.IsKeyDown(Keys.Right))
                return new Position(0, 1);
            return new Position(0, 0);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, SpriteFont font)
        {
            map.Draw(spriteBatch, painter);
            player.Draw(spriteBatch, new Vector2(player.Position.Y * painter.ElementSize + painter.OffsetY, player.Position.X * painter.ElementSize + painter.OffsetX), painter, font);
        }

        public bool CheckWin()
        {
            foreach (var box in map.Boxes)
                if (box.InParking == false)                
                    return false;
            return true;
                
        }

    }
}
