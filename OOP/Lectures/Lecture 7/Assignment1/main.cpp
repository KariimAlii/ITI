#include <iostream>
using namespace std;

class Base
{
protected:
    int x;
    int y;

public:
    Base() { x = y = 0; }
    Base(int m) { x = y = m; }
    Base(int m, int n)
    {
        x = m;
        y = n;
    }

    int GetX() { return x; }
    int GetY() { return y; }

    void SetX(int m) { x = m; }
    void SetY(int n) { y = n; }

    int Sum()
    {
        cout << "I summed x+y" << endl;
        return (x + y);
    }
    virtual int Product()
    {
        cout << "I multiplied x*y" << endl;
        return (x * y);
    }
};
class Derived1 : public Base
{
protected:
    int a;

public:
    Derived1() : Base()
    {
        a = 0;
    }
    Derived1(int l, int m, int n) : Base(l, m)
    {
        a = n;
    }
    int GetA() { return a; }
    void SetA(int m) { a = m; }
    int Sum()
    {
        cout << "I summed x+y+a" << endl;
        return (x + y + a);
    }
    int Product()
    {
        cout << "I multiplied x*y*a" << endl;
        return (x * y * a);
    }
};
class Derived2 : public Derived1
{
protected:
    int b;

public:
    Derived2() : Derived1()
    {
        b = 0;
    }
    Derived2(int l, int m, int n, int r) : Derived1(l, m, n)
    {
        b = r;
    }
    int GetB() { return a; }
    void SetB(int m) { a = m; }
    int Sum()
    {
        cout << "I summed x+y+a+b" << endl;
        return (x + y + a + b);
    }
    int Product()
    {
        cout << "I multiplied x*y*a*b" << endl;
        return (x * y * a * b);
    }
};

void line()
{
    cout << "------------------"
         << endl;
}
    
void wall()
{
    cout << "********************************"
         << endl;
}
int main()
{
    Derived2 obj(3, 4, 5, 6);
    Base *P;
    Derived1 *P1;
    Derived2 *P2;
    P = P1 = P2 = &obj;
    //===Base Pointer===//
        wall();
        wall();
    P->Sum();
        line();
    P->Base::Sum();
        line();
    P->Product();
        wall();
        wall();
    //===Derived1 Pointer===//
    P1->Sum();
        line();
    P1->Derived1::Sum();
    P1->Base::Sum();
        line();
    P1->Product();
        wall();
        wall();
    //===Derived2 Pointer===//
    P2->Sum();
        line();
    P2->Derived2::Sum();
    P2->Derived1::Sum();
    P2->Base::Sum();
        line();
    P2->Product();
        wall();
        wall();
    return 0;
}

// void Print(Base *P)
// {
//     cout << P->Product();
// }
