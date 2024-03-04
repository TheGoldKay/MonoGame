using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


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
		Vector2 last;
		int initial_length;
		public bool isDead = false;
		public MakeSnake(Texture2D part, Texture2D head, Vector2 headPos, int mon_width, int mon_height, int initial_length = 5)
		{
			this.part = part;
			this.head = head;
			this.size = part.Width;
			this.initial_length = initial_length;
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
			for(int i = 0; i < initial_length; i++)
			{
				Vector2 pos = new Vector2(head.X + this.size * i, head.Y);
				parts.Add(pos);
			}
			return parts;
		}
		public Vector2 getHead()
		{
			return this.body[0];
		}
		public int getSize()
		{
			return this.size;
		}
		public void grow()
		{
			body.Add(last);
		}
		public void checkDeath()
		{
			var headRect = new Rectangle((int)this.body[0].X, (int)this.body[0].Y, this.size, this.size);
			for(int i = 2; i < this.body.Count; i++)
			{
				var pos = this.body[i];
				var bodyRect = new Rectangle((int)pos.X, (int)pos.Y, this.size, this.size);
				if(headRect.Intersects(bodyRect))
				{
					isDead = true;
				}
			}
		}
		public void update(float dt)
		{
			if(!isDead)
			{
				move(dt);
			}
		}
		public void move(float dt)
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
				}
				if(head.Y < 0)
				{
					head.Y = this.monitor_height;
				}else if(head.Y > this.monitor_height)
				{
					head.Y = 0;
				}
                this.body.Insert(0, head);
				last = this.body[^1];
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
