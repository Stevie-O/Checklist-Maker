using System;
using System.IO;
using System.Collections.Generic;

class clist
{
	private string name;
	private string associated_file;
	private List<string> items;
	private bool dirty;

	public clist(string list_name, string file_name)
	{
		name = list_name;
		associated_file = file_name;
		items = new List<string>();
		set_dirty(true);
	}

	public void add_item(string new_item)
	{
		string item_data = "[ ] - " + new_item;
		items.Add(item_data);
		set_dirty(true);
	}

	public string get_name()
	{	
		return this.name;
	}

	public void print_list(TextWriter w)
	{
		foreach (var item in items)
		{
			w.WriteLine(item);
		}
	}

	public bool get_state() { return this.dirty; }


	public void save()
	{
		if (dirty) // if the state of the object is clean
			return;
		else if (!dirty) // if the state of the object is dirty
			write_file();
	}
	
	private void read_file()
	{
		using (StreamReader sr = new StreamReader(associated_file))
		{
			sr.ReadLine(); // skip the first line, which is the name of the list
			string line;
			while ((line = sr.ReadLine()) != null)
			{
				items.Add(line);
			}
		}

		set_dirty(false);
	}

	private void write_file()
	{
		using (StreamWriter sw = new StreamWriter(associated_file))
		{
			sw.WriteLine(this.name);
			foreach (var item in items)
				sw.WriteLine(item);		
		}

		set_dirty(false);
	}

	private void set_dirty(bool is_dirty)
	{
		dirty = is_dirty;
	}
}
