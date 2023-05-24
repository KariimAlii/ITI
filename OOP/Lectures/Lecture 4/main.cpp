#include <iostream>
using namespace std;
class Complex {
private:
    int Real;
    int Imag;
public:
    //========Constructors==========//
    Complex() {Real = 0; Imag = 0;};
    explicit Complex(int m) {Real = Imag = m;};
    Complex(int m , int n) {Real = m ; Imag = n;};
    //======Setters======//
    void SetR (int m) {Real = m;};
    void SetI (int n) {Imag = n;};
    //======Getters======//
    int GetR () {return Real;};
    int GetI () {return Imag;};
    //====Operators====//

    // Complex Caller + Complex C
    Complex operator+ (Complex C);
    // Complex Caller + int m
    Complex operator+ (int m);
    // Complex Increment
    Complex operator++();
    // Complex Increment using dummy integer variable
    Complex operator++(int d);
    // Comparison if Complex caller == Complex C
    int operator== (Complex C);
    // Assignment Operator (=) Complex caller = Complex C
    Complex operator= (Complex C);

    // friend functions
    friend Complex operator+ (int m , Complex C);
    // Casting  Complex --> int
    operator int() const;
};
void print(Complex C);
int main() {
    Complex C1(1);
    Complex C2(2,3);
    Complex C3;
    cout << "//===============================================================" <<endl;
    cout << "***C1***" <<endl;
    print(C1);

    cout << "***C2***" <<endl;
    print(C2);

    cout << "***C3***" <<endl;
    print(C3);
    cout << "//===============================================================" <<endl;

    C3 = C1 + C2;
    cout << "*** C3 = C1 + C2 ***" <<endl;
    print(C3);

    cout << "//===============================================================" <<endl;

    Complex C4;
    C4 = C3 + 3 ;
    cout << "*** C4 = C3 + 3 ***" <<endl;
    print(C4);
    cout << "//===============================================================" <<endl;
    cout << "*** PreIncrement C5 = ++C4 ***" <<endl;
    Complex C5;
    C5 = ++C4;

    print(C5);
    cout << "//===============================================================" <<endl;
    cout << "*** PostIncrement C6 = C5++ ***" <<endl;
    Complex C6;
    C6 = C5++;
    print(C6);
    cout << "//===============================================================" <<endl;

    Complex C7;
    C7 = C6;
    cout << "*** C7 ***" <<endl;
    print(C7);
    cout << "*** Equality Check C7 == C6 ? ***" <<endl;
    if (C7 == C6) cout << "True !" <<endl;
    else cout << "False" <<endl;
    cout << "//===============================================================" <<endl;

    Complex C8;
    C8 = C7 + 2;
    cout << "*** C8 ***" <<endl;
    print(C8);
    cout << "*** Equality Check C8 == C7 ? ***" <<endl;
    if (C8 == C7) cout << "True !" <<endl;
    else cout << "False" <<endl;
    cout << "//===============================================================" <<endl;
    cout << "*** Friend Function ***" <<endl;
    cout << "*** C9 = 5 + C8 ***" <<endl;
    Complex C9;
    C9 = 5 + C8;
    cout << "*** C9 ***" <<endl;
    print(C9);
    cout << "//===============================================================" <<endl;
    cout << "*** Casting (int)C9 ***" <<endl;
    int i ;
    i = (int) C9;
    cout << "i = " << i <<endl;

    return 0;
}
// User Functions
void print(Complex C) {
    cout << "R = " << C.GetR() << endl;
    cout << "I = " << C.GetI() << endl;
}
//====Operators====//

// Complex Caller + Complex C [ C = C1 + C2 ]
Complex Complex::operator+ (Complex C) {
    Complex temp;
    temp.Real = Real + C.Real;
    temp.Imag = Imag + C.Imag;
    return temp;
}
// Complex Caller + int m [ C = C1 + m ]
Complex Complex::operator+ (int m) {
    Complex temp;
    temp.Real = Real + m;
    temp.Imag = Imag;
    return temp;
//    You can use constructor
//    Complex temp (Real+m , Imag);
}
// Pre Increment  ++c
Complex Complex::operator++() {
    Real++;
    Imag++;
    return *this;
}
// Post Increment using dummy integer variable  c++
Complex Complex::operator++(int d) {
    Complex old;
    old = *this;
    Real++;
    Imag++;
    return old;
    //===================
//    Complex old;
//    old.Real = Real++;
//    old.Imag = Imag++;
//    return old;
    //===================
//    Complex old(Real++,Imag++);
//    return old;
    //===================
//    Complex old;
//    old = *this;
//    *this = *this + 1;
//    return old;

}
// Comparison if Complex caller == Complex C
int Complex::operator== (Complex C) {
//    int retval = 0;
//    if (Real == C.Real && Imag == C.Imag) retval = 1;
//    return retval;
    //===============================================
    return (Real == C.Real && Imag == C.Imag) ; // Zero (False) or NonZero (True)
}
// Assignment Operator (=) Complex caller = Complex C
Complex Complex::operator= (const Complex C) {
    Real = C.Real;
    Imag = C.Imag;
    return *this;
    //========================
//    return C ;
}

// friend functions
Complex operator+ (int m , Complex C) {
    Complex temp;
    temp.Real = m + C.Real;
    temp.Imag = m + C.Imag;
    return temp;
    //==============================
//    return (C+m);
}
// Casting  Complex --> int
Complex::operator int() const {
    return Real;
}
