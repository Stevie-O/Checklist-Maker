#include <iostream>
#include <string>
#include <vector>
#include "cl.h"

using namespace std;

class checklist
{
public:
	checklist(){}
	virtual ~checklist(){}

	void add_checklist(){
		char	input;
		string	name;
		string	file_name;

		cout << "Please enter a name for the list (if empty, default name will be assigned): " << endl;
		getline(cin, name);
		if (name.empty()){
			name = "Default";
		}

		cout << "Please enter a file name for the list (if blank, filename will default to lists name): " << endl;
		getline(cin, file_name);
		if (file_name.empty() || file_name == ".txt"){
			file_name = name + ".txt";
		}
		else if (!file_name.find(".txt")){
			file_name += ".txt";
		} 
		
		// Assures there's no objects with duplicate names in the list
		while (check_duplicate(name)){
			cout << name << " already exists in the list, adjusting to fit in list." << endl;
			name = "_" + name;
		}
		clists.push_back(new clist(name, file_name));
	}


private:

	// Checks for any duplicates in the list.
	bool check_duplicate(string search_key){
		for (auto i : clists){
			if (i->get_name() == search_key){
				return true;
			}
		}
		return false;
	}

	vector<clist*>	clists;
};



int main(void){
	checklist*	list_of_checks = new checklist();


	cout << "Hello world!" << endl;
	return 0;
}