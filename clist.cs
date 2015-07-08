using System;
using System.IO;
using System.Collections.Generic;

class clist
{
	private string name;
	private string associated_file;
	private List<string> items;
	private bool state;

	public clist(string list_name, string file_name)
	{
		name = list_name;
		associated_file = file_name;
		state = false;
		items = new List<string>();
	}

	public void add_item(string new_item)
	{
		string item_data = "[ ] - " + new_item;
		items.Add(item_data);
		change_state(false);
	}

	public string get_name()
	{	
		return this.name;
	}

	public void print_list()
	{
		foreach (var item in items)
		{
			Console.WriteLine(item);
		}
	}

	public bool get_state() { return this.state; }


	public void save()
	{
		if (state) // if the state of the object is clean
			return;
		else if (!state) // if the state of the object is dirty
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

		change_state(false);
	}

	private void write_file()
	{
		using (StreamWriter sw = new StreamWriter(associated_file))
		{
			sw.WriteLine(this.name);
			foreach (var item in items)
				sw.WriteLine(item);		
		}

		change_state(true);
	}

	private void change_state(bool new_state)
	{
		state = new_state;
	}
}
