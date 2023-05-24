#include <iostream>

using namespace std;
class Stack
{
    int *ar;
    int tos;
    int Size;

public:
    int Push(int m);
    int Pop();
    //==Getters==//
    int GetSize() { return Size; }; // Inline Function
    int GetTos() { return tos; };   // Inline Function
    //==Constructors==//
    Stack();
    Stack(int S);
    //==Destructor==//
    ~Stack() { delete (ar); };
    //==Copy Constructor==//
    Stack(Stack &rst);
    Stack& operator=(const Stack& S);
};
Stack FillStack();
void PrintStack(Stack St);
int main()
{
    Stack Stk;
    Stk = FillStack();
    PrintStack(Stk);
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
// OverLoading : Contructors with different Signatures
//=====Default Constructor=====//
Stack::Stack()
{
    tos = 0;
    Size = 10;
    ar = new int[Size];
}
//=====Parameterized Constructor=====//
Stack::Stack(int S)
{
    tos = 0;
    Size = S;
    ar = new int[Size];
}
// WE CAN COMBINE BOTH IN ONE USING DEFAULT ARGUMENT VALUE
//=========================================================
// Stack::Stack(int S = 10) {
//     tos = 0;
//     Size = S;
//     ar = new int[Size];
// }

Stack FillStack()
{
    int s, m;
    cout << "Enter The Required Stack Size    ";
    cin >> s;
    Stack St(s);
    for (int i = 0; i < St.GetSize(); i++)
    {
        cout << "Enter a number to add to stack !    ";
        cin >> m;
        St.Push(m);
    }
    return St;
}
void PrintStack(Stack St)
{
    int Nitems;
    Nitems = St.GetTos(); // Number of items stored in stack
    for (int i = 0; i < Nitems; i++)
    {

        cout << St.Pop() << "-->";
    }
}
Stack::Stack(Stack &rst)
{
    Size = rst.Size;
    tos = rst.tos;
    ar = new int[Size];
    for (int i = 0; i < tos; i++)
    {
        ar[i] = rst.ar[i];
    }
}
Stack &Stack::operator=(const Stack &S)
{
    Size = S.Size;
    tos = S.tos;
    delete (ar);
    ar = new int[Size];
    for (int i = 0; i < Size; i++)
    {
        ar[i] = S.ar[i];
    }
    return *this;
}