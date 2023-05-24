#include <iostream>

using namespace std;
class Shape
{
protected:
    int dim1,dim2;
public:
    Shape() {dim1 = dim2 = 0;}
    Shape(int m) {dim1 = dim2 = m;}
    Shape (int m , int n) {dim1 = m ; dim2 = n ;}

    void SetD1 (int m ) {dim1 = m;}
    void SetD2 (int n) {dim2 = n;}

    int GetD1 () {return dim1;}
    int GetD2 () {return dim2;}
    
    virtual float Area() = 0;
};
class Circle :public Shape
{
public:
    Circle() {};
    Circle (int r) : Shape (r) {}
    float Area () {return 3.14 * dim1 * dim2 ;}
};
class Rectangle :public Shape
{
public:
    Rectangle() {};
    Rectangle (int l , int w) : Shape (l,w) {}
    float Area () {return 1.0 * dim1 * dim2 ;}
};
class Triangle :public Shape
{
public:
    Triangle() {};
    Triangle (int l , int w) : Shape (l,w) {}
    float Area () {return 0.5 * dim1 * dim2 ;}
};
class Square :public Rectangle
{
public:
    Square() {};
    Square (int s) : Rectangle (s,s) {}
};
class GeoShape
{
    Shape* P[4];
public:
    GeoShape(Shape* P1 , Shape* P2 , Shape* P3 , Shape* P4 )
    {
        P[0] = P1;
        P[1] = P2;
        P[2] = P3;
        P[3] = P4;
    }
    float TotalArea ()
    {
        float Total = 0;
        for (int i = 0 ; i < 4 ; i++)
        {
            Total += P[i]->Area();
        }
        return Total;
    }
};
int main() {
    Circle C (7);
    Rectangle R (20,5);
    Triangle T (10,20);
    Square S (6);
    GeoShape g(&C,&R,&T,&S);
    cout << "Total Area = " <<g.TotalArea();
    return 0;
}

//============================================================================================
//============================================================================================
//class GeoShape
//{
//    Shape* pC;
//    Shape* pR;
//    Shape* pT;
//    Shape* pS;
//public:
//    GeoShape(Shape* P1 , Shape* P2 , Shape* P3 , Shape* P4 )
//    {
//        pC = P1;
//        pR = P2;
//        pT = P3;
//        pS = P4;
//    }
//    float TotalArea ()
//    {
//        float Total;
//        Total = pC->Area() + pR->Area() + pT->Area() + pS->Area() ;
//        return Total;
//    }
//};




