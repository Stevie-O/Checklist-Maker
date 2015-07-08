#include "cl.h"
#include <iostream>
#include <fstream>
#include <vector>
#include <string>

using namespace std;

clist::clist(string list_name, string file_name){
	name = list_name;
	associated_file = file_name;
	state = false;
}

clist::~clist(){
	// Objects held by this object
	// Will take care of themselves when
	// deletion occurs.
}


// Public Members
void clist::add_item(string new_item){
	items.push_back("[ ] - " + new_item);
	change_state(false);
}

string clist::get_name(){
	return this->name;
}

void clist::print_list(){
	cout << name << endl;
	for (auto index : items){
		cout << index << endl;
	}
	cout << "End of " << name << " checklist\n\n";
}

const bool clist::get_state(){
	return state;
}

void clist::save(){
	if (state){ // If the state of the object is clean
		return;
	}
	else if (!state){ // If the state of the object is dirty
		write_file();
	}
}


// Private Members
void clist::read_file(){
	ifstream		my_file;

	string			holder;

	my_file.open(associated_file);
	
	if (!my_file){
		cerr << "Cannot open file: " << associated_file << endl;
		return;
	}

	while (!my_file.eof()){
		getline(my_file, holder);
		add_item(holder);
		my_file.ignore(1, '\n');
	}
	change_state(false);
}

void clist::write_file(){
	ofstream			my_file;

	my_file.open(associated_file);

	if (!my_file){
		cerr << "Cannot open file: " << associated_file << endl;
		return;
	}

	my_file << name << endl;

	for (auto index : items){
		my_file << index << endl;
	}
	change_state(true);
}

void clist::change_state(bool new_state){
	state = new_state;
}