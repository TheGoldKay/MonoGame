using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnakeBody
{
	public class MakeSnake
	{
		//private SpriteBatch spriteBatch;
		Texture2D part;
		List<Vector2> body;
		int size;
		public MakeSnake(Texture2D part, Vector2 headPos)
		{
			this.part = part;
			this.size = part.Width;
			this.body = makeParts(headPos);
		}
		private List<Vector2> makeParts(Vector2 head)
		{
			List<Vector2> parts = new List<Vector2>();
			for(int i = 0; i < 3; i++)
			{
				Vector2 pos = new Vector2(head.X + this.size * i, head.Y);
				parts.Add(pos);
			}
			return parts;
		}
		public void draw(SpriteBatch batch)
		{
			foreach(var piece in this.body)
			{ 
				batch.Draw(this.part, piece, Color.White);
			}
		}
	}
}
