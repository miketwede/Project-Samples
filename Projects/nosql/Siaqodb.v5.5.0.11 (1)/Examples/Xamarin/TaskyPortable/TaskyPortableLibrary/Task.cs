using System;


namespace Tasky.BL
{
	/// <summary>
	/// Represents a Task.
	/// </summary>
	public class Task
	{
		public Task ()
		{
		}


		public int OID { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
		public bool Done { get; set; }
	}
}

