#include <iostream>
#include <string>
#include <vector>
#include "clist.h"
#include "clmanager.h"

using namespace std;

void display_menu();
char get_char();

int main(void){
	checklist*	list_of_checks = new checklist();

	list_of_checks->add_checklist();
	list_of_checks->add_checklist();

	list_of_checks->print_lists();

	cin.get();
	return 0;
}