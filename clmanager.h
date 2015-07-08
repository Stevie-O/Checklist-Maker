#ifndef __CLMANAGER_H__
#define __CLMANAGER_H__

#include <string>
#include <iostream>
#include "clist.h"

class checklist
{
public:
	checklist(){}
	virtual ~checklist(){}

	void add_checklist();
	void print_lists();

private:
	// Checks for any duplicates in the list.
	bool check_duplicate(std::string);

	std::vector<clist*>	clists;
};

#endif