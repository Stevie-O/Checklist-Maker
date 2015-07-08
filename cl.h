#ifndef __CL_H__
#define __CL_H__

#include <vector>
#include <string>

class clist
{
public:
	clist(std::string, std::string);	// Name & File Constructor
	virtual ~clist();

	// Mutators
	void add_item(std::string);

	// Accessors
	std::string get_name();
	void print_list();
	const bool get_state();
	
	// Only public state managing function.
	// Checks if the state of the object is clean or dirty.
	// If dirty then the object is saved and the state is changed to clean.
	// If clean then the function returns without changing the file.
	void save();

private:
	// State managers
	void read_file();
	void write_file();
	void change_state(bool);

	std::string					name;
	std::string					associated_file;
	std::vector<std::string>	items;
	bool						state;	// true: Clean, false: Dirty
};

#endif