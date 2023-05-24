#include <iostream>
#include <string.h>
using namespace std;
class Subject
{
private:
    char name[20];
};
//==========================================================================
class People
{
private:
    Subject** S; //==Association==//
    char name[20];
    int id;
public:
    People()
    {
        strcpy(name,"abc");
        id = 0;
        S = NULL;
    }
    People (char name[] , int id)
    {
        strcpy(this->name,name);
        this->id = id;
    }
};
//==========================================================================
class Student : public People //==Inheritance==//
{
public:
    Student(char name[] , int id) : People(name,id) {}
};
//==========================================================================
class Staff : public People //==Inheritance==//
{
public:
    Staff(char name[] , int id) : People(name,id) {}
};
//==========================================================================
class ITI
{
private:
    People** P; //==Composition==//
public:

};
int main() {

    return 0;
}
