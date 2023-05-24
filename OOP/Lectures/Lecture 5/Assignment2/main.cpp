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
class Rectangle_C {
private:
    Point P1,P2;
    int Length,Width;
public:
    Rectangle_C(int x1,int x2,int y1,int y2);
    void setP1(int x , int y);
    void setP2(int x , int y);
    int Area() {return (Length * Width) ;};
};
int main() {
    Rectangle_C rect(20,13,14,17);
    cout << "Area = " << rect.Area() <<endl; // (20 - 13 ) * (14 - 17) = 7 * 3
    rect.setP1(19,13);
    cout << "Area = " << rect.Area() <<endl; // (19 - 13) * (13 - 17) = 6 * 4
    return 0;
}
Rectangle_C::Rectangle_C(int x1,int x2,int y1,int y2) : P1(x1,y1) , P2(x2,y2) {
//    P1.SetX(x1);
//    P1.SetY(y1);
//    P2.SetX(x2);
//    P2.SetY(y2);
    Length = abs(x2 - x1);
    Width = abs(y2 - y1);
}
void Rectangle_C::setP1(int x , int y) {
    P1.SetX(x);
    P1.SetY(y);
    Length = abs(x - P2.GetX());
    Width = abs(y - P2.GetY());
}
void Rectangle_C::setP2(int x , int y) {
    P2.SetX(x);
    P2.SetY(y);
    Length = abs(x - P2.GetX());
    Width = abs(y - P2.GetY());
}
