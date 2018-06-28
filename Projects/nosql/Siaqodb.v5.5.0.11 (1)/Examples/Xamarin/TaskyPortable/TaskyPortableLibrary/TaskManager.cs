using System;
using System.Collections.Generic;
using Tasky.BL;
using Sqo;
using System.Linq;
namespace Tasky.BL.Managers
{
	public class TaskManager
	{
		ISiaqodb siaqodb = null;


		public TaskManager (ISiaqodb siaqodb) 
        {
			this.siaqodb = siaqodb;
        }

		public Task GetTask(int oid)
		{
			return siaqodb.LoadObjectByOID<Task> (oid);
		}
		
		public IList<Task> GetTasks ()
		{
			var q = from Task t in siaqodb
					where t.Done == false
					select t;

			return q.ToList();
		}
		
		public void SaveTask (Task item)
		{
			 siaqodb.StoreObject (item);
		}
		
		public void DeleteTask(Task task)
		{
			siaqodb.Delete (task);
		}
		
	}
}