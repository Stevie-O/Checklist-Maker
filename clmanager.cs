using System;
using System.IO;
using System.Collections.Generic;

class checklist
{
	static void writeln(string message) { Console.WriteLine(message); }
	static void writeln(string format, params object[] args) { Console.WriteLine(format, args); }
	static string readln() { return Console.In.ReadLine(); }

	public void add_checklist(){
		string	name;
		string	file_name;

		writeln("Please enter a name for the list (if empty, default name will be assigned): ");
		name = readln();

		if (string.IsNullOrEmpty(name))
		{
			name = "Default";
		}

		writeln("Please enter a file name for the list (if blank, filename will default to lists name): ");
		file_name = readln();
		if (string.IsNullOrEmpty(file_name) || file_name == ".txt"){
			file_name = name + ".txt";
		}
		else if (file_name.IndexOf(".txt") < 0){
			file_name += ".txt";
		} 
		
		// Assures there's no objects with duplicate names in the list
		while (check_duplicate(name)){
			writeln("{0} already exists in the list, adjusting to fit in list.", name);
			name = "_" + name;
		}
		clists.Add(name, new clist(name, file_name));
	}

	// Checks for any duplicates in the list.
	bool check_duplicate(string search_key){
		return clists.ContainsKey(search_key);
	}

	public void print_lists()
	{
		foreach (var list in clists.Values)
		{
			list.print_list();
		}
	}

	SortedDictionary<string, clist> clists = new SortedDictionary<string, clist>();
}
