#include <iostream>

using namespace std;

#define Size 10

class Stack
{
    int ar[Size];
    int tos;

public:
    int Push(int m);
    int Pop();
    Stack() {tos = 0;}
};
int main()
{
    Stack st1;
    st1.Push(11);
    st1.Push(19);
    cout << "ST1:" << endl
         << st1.Pop() << endl
         << st1.Pop() << endl;
         
    Stack st2;
    st2.Push(27);
    st2.Push(45);
    cout << "ST2:" << endl
         << st2.Pop() << endl
         << st2.Pop() << endl;
    return 0;
}
int Stack::Push(int m)
{
    int retval = 0;
    if (tos < Size)
    {
        ar[tos] = m;
        tos++;
        retval = 1;
    }
    return retval;
}
int Stack::Pop()
{
    int retval = -1;
    if (tos > 0)
    {
        tos--;
        retval = ar[tos];
    }
    return retval;
}