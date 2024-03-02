using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;


namespace SnakeBody
{
	public class MakeSnake
	{
		//private SpriteBatch spriteBatch;
		Texture2D part;
		Texture2D head;
		List<Vector2> body;
		int size;
		float timer;
		float clock;
		string dir;
		int monitor_width;
		int monitor_height;
		public MakeSnake(Texture2D part, Texture2D head, Vector2 headPos, int mon_width, int mon_height)
		{
			this.part = part;
			this.head = head;
			this.size = part.Width;
			this.body = makeParts(headPos);
			this.monitor_width = mon_width;
			this.monitor_height = mon_height;
			this.timer = 0.2f;
			this.clock = 0;
			this.dir = "left";
		}
		private List<Vector2> makeParts(Vector2 head)
		{
			List<Vector2> parts = new List<Vector2>();
			for(int i = 0; i < 15; i++)
			{
				Vector2 pos = new Vector2(head.X + this.size * i, head.Y);
				parts.Add(pos);
			}
			return parts;
		}
		public void update(float dt)
		{
			keypress();
			this.clock += dt;
			if(clock > this.timer)
			{
                Vector2 head = this.body[0];
                if(this.dir == "left")
				{
					head.X -= this.size;
				}else if(this.dir == "right")
				{
					head.X += this.size;
				}else if(this.dir == "up")
				{
					head.Y -= this.size;
				}else if(this.dir == "down")
				{
					head.Y += this.size;
				}
				if(head.X < 0)
				{
					head.X = this.monitor_width;
				}else if(head.X > this.monitor_width)
				{
					head.X = 0;
				}else if(head.Y < 0)
				{
					head.Y = this.monitor_height;
				}else if(head.Y > this.monitor_height)
				{
					head.Y = 0;
				}
                this.body.Insert(0, head);
                this.body.RemoveAt(this.body.Count - 1);
				this.clock = 0;
            }

		}
		private void keypress()
		{
			KeyboardState state = Keyboard.GetState();
			if(state.IsKeyDown(Keys.W) && this.dir != "down")
			{
				this.dir = "up";
			}else if (state.IsKeyDown(Keys.S) && this.dir != "up")
            {
                this.dir = "down";
            }else if (state.IsKeyDown(Keys.A) && this.dir != "right")
            {
                this.dir = "left";
            }else if (state.IsKeyDown(Keys.D) && this.dir != "left")
            {
                this.dir = "right";
            }
        }
		public void draw(SpriteBatch batch)
		{
			batch.Draw(this.head, this.body[0], Color.BurlyWood);
			for(int i = 1; i < this.body.Count; i++)
			{ 
				batch.Draw(this.part, this.body[i], Color.White);
			}
		}
	}
}
