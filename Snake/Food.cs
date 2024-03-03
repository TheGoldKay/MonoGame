using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using Microsoft.Xna.Framework.Content;
using System.Numerics;


namespace Food
{
    public class MakeFood
    {
        Texture2D food;
        Microsoft.Xna.Framework.Vector2 foodPos;
        List<Texture2D> fruits;
        ContentManager content;
        int win_width, win_height;
        int width, height;
        public MakeFood(ContentManager content, int win_width, int win_height)
        {
            this.content = content;
            this.win_width = win_width;
            this.win_height = win_height;
            loadFruits();
            placeFood();
        }
        private void loadFruits()
        {
            fruits = new List<Texture2D>();
            var files = from file in Directory.EnumerateFiles(@"Content\FRUIT_LINE") select file;
            foreach(var file in files)
            {
                var name = file.Split('\\').Last().Split('.').First();
                var fruit = this.content.Load<Texture2D>(@$"FRUIT_LINE\{name}");
                fruits.Add(fruit);
            }
        }
        public void placeFood()
        {
            var index = new Random().Next(0, fruits.Count);
            food = fruits[index];            
            int x = new Random().Next(0, win_width - 30);
            int y = new Random().Next(0, win_height - 30);
            width = food.Width;
            height = food.Height;
            foodPos = new Microsoft.Xna.Framework.Vector2(x, y); 
        }
        public void draw(SpriteBatch batch)
        {
            batch.Draw(food, foodPos, Color.White);
        }
        public bool eaten(Microsoft.Xna.Framework.Vector2 headPos, int headSize)
        {
            var rect = new Rectangle((int)foodPos.X, (int)foodPos.Y, width, height);
            var headRect = new Rectangle((int)headPos.X, (int)headPos.Y, headSize, headSize);
            return headRect.Intersects(rect);
        }
    }
}