#include <iostream>
#include <math.h>
using namespace std;
class Point {
private:
    int X;
    int Y;
public:
    Point() {X = Y = 0;};
    Point(int m) {X = Y = m;};
    Point(int m,int n) {X = m; Y = n;};

    int GetX() {return X;};
    int GetY() {return Y;};

    void SetX(int m) {X = m;};
    void SetY(int n) {Y = n;};

};
class Rectangle_A {
private:
    Point *P1,*P2;
    int Length,Width;
public:
    Rectangle_A();
    Rectangle_A(Point *Pa,Point *Pb);
    void setP1(Point *P);
    void setP2(Point *P);
    void CalcDimensions ();
    int Area() {return (Length * Width) ;};
};
int main() {
    Point a(4,6);
    Point b(2,3);
    Rectangle_A rect(&a,&b);
    cout << "Area = " << rect.Area() <<endl; 
// a,b ==> (4 - 2 ) * (6 - 3) = 2 * 3 = 6
    Point c(8,10);
    rect.setP1(&c);
    cout << "Area = " << rect.Area() <<endl; 
// c,b ==> (8 - 2) * (10 - 3) = 6 * 7 = 42
    return 0;
}
Rectangle_A::Rectangle_A() {
    P1 = P2 = NULL;
    Length = Width = 0;
}
Rectangle_A::Rectangle_A(Point *Pa,Point *Pb)  {
    P1 = Pa;
    P2 = Pb;
    CalcDimensions();
}
void Rectangle_A::setP1(Point *P) {
    P1 = P;
    CalcDimensions();
}
void Rectangle_A::setP2(Point *P) {
    P2 = P;
    CalcDimensions();
}
void Rectangle_A::CalcDimensions () {
    if (P1 != NULL && P2 != NULL) {
        Length = abs(P1->GetX() - P2->GetX());
        Width = abs(P1->GetY() - P2->GetY());
    } else {
        Length = Width = 0;
    }
}
