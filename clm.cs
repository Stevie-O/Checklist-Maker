using System;

class Clm {
	static int Main()
	{
		checklist list_of_checks = new checklist();
		
		list_of_checks.add_checklist();
		list_of_checks.add_checklist();
		list_of_checks.print_lists();
	
		Console.ReadLine();
		return 0;
	}
}

