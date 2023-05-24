#include <iostream>
using namespace std;
class Base
{
protected:
    float x ,y;
public:
    Base() { x=2;y=1;}
    Base(float a , float b) {x=a;y=b;}
    virtual void printSum() = 0;
};
class Derived : public Base
{
protected:
    float z;
public:
    Derived(float a , float b , float c):Base()
    {
        z = c;
    }
    void showSum()
    {
        cout << x+y+z;
    }
    // void printSum() {}
};
int main() {
    //==========4=============//
    Base* myPtr;
    Derived myDerived(15,5,4);
    myDerived.showSum();
    return 0;
}
