#include <iostream>
using namespace std;
class Complex {
private:
    static int Count;
    int Real;
    int Imag;
public:
    Complex() {Real = Imag = 0; Count++;};
    Complex(int m) {Real = Imag = m; Count++;};
    Complex (int m , int n) {Real = m ; Imag = n; Count++;};

    int GetR () {return Real;};
    int GetI () {return Imag;};
    void SetR (int r) {Real = r;};
    void SetI (int i) {Imag = i;};

    ~ Complex () {Count--;};
    static int GetCount () {return Count;}
};
int Complex::Count = 0;
int main() {
    Complex C1,C2(2),C3(4,5);
    cout << Complex::GetCount() <<" objects Created with class Complex !" <<endl;
    return 0;
}
