#include <iostream>

using namespace std;

class Complex
{
    private : 
        int Real;
        int Imag;
    public : 
        Complex Add(Complex C2);
        void Print();
        void SetComplex(int r, int i);
};

int main()
{
    Complex cpl1, cpl2, cpl3;

    cpl1.SetComplex(7, 9);
    cpl2.SetComplex(14, 20);

    cpl3 = cpl1.Add(cpl2);
    cpl3.Print();
    return 0;
}
Complex Complex::Add(Complex C2)
{
    Complex temp;
    temp.Real = this->Real + C2.Real;
    temp.Imag = this->Imag + C2.Imag;
    return temp;
}
void Complex::Print()
{
    cout << "Real = " << this->Real << endl;
    cout << "Imag = " << this->Imag << endl;
}

void Complex::SetComplex(int r, int i)
{
    this->Real = r;
    this->Imag = i;
}