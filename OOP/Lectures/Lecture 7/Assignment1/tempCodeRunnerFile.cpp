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