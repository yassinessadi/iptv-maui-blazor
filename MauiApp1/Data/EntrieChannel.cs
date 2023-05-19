﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Data
{
	public class EntrieChannel
	{
		public string Name { get; set; }
		public string Id => Letter();
		public string ImageUrl { get; set; }
		public string Url { get; set; }
		public string GroupTitle { get; set; }

		private string Letter()
		{
			if (string.IsNullOrEmpty(Name))
			{
				return "X";
			}
			else
			{
				return Name.Substring(0, 1);
			}
		}
	}
}
