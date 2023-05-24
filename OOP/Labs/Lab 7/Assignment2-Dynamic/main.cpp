#include <iostream>

using namespace std;


class Shape
{
protected:
    int dim1, dim2;

public:
    Shape() { dim1 = dim2 = 0; }
    Shape(int m) { dim1 = dim2 = m; }
    Shape(int m, int n)
    {
        dim1 = m;
        dim2 = n;
    }
    void SetD1(int m) { dim1 = m; }
    void SetD2(int n) { dim2 = n; }
    int GetD1() { return dim1; }
    int GetD2() { return dim2; }
    virtual float Area() = 0;
};
class Circle : public Shape
{
public:
    Circle(){};
    Circle(int r) : Shape(r) {}
    float Area() { return 3.14 * dim1 * dim2; }
};
class Rectangle : public Shape
{
public:
    Rectangle(){};
    Rectangle(int l, int w) : Shape(l, w) {}
    float Area() { return 1.0 * dim1 * dim2; }
};
class Triangle : public Shape
{
public:
    Triangle(){};
    Triangle(int l, int h) : Shape(l, h) {}
    float Area() { return 0.5 * dim1 * dim2; }
};
class Square : public Rectangle
{
public:
    Square(){};
    Square(int s) : Rectangle(s, s) {}
};
class GeoShape
{
    Shape **P;

public:
    GeoShape(Shape **ptr)
    {
        this->P = ptr;
    }
    float TotalArea(int nShapes)
    {
        float Total = 0;
        for (int i = 0; i < nShapes; i++)
        {
            Total += P[i]->Area();
        }
        return Total;
    }
};

//============================================================================
//=============================Dynamic ALlocation===========================//
//============================================================================

int main()
{
    int nShapes = 0;
    cout << "Enter the Required Number of Shapes You need:";
    cin >> nShapes;
    Shape **P = NULL;
    P = new Shape *[nShapes];
    for (int i = 0; i < nShapes; i++)
    {
        int shapeNumber = 0;
        cout << "Enter The Shape (" 
             << i + 1 << ") Number:" 
             << endl;
        cin >> shapeNumber;
        switch (shapeNumber)
        {
        case (1): // Circle
        {
            int r = 0;
            cout << "Enter Circle Radius:";
            cin >> r;
            // Circle C (r);
            // P[i] = &C;
            P[i] = new Circle(r);
            break;
        }
        case (2): // Rectangle
        {
            int l = 0, w = 0;
            cout << "Enter Length:";
            cin >> l;
            cout << "Enter Width:";
            cin >> w;

            P[i] = new Rectangle(l, w);
            break;
        }
        case (3): // Triangle
        {
            int base = 0, height = 0;
            cout << "Enter Base:";
            cin >> base;
            cout << "Enter Height:";
            cin >> height;

            P[i] = new Triangle(base, height);
            break;
        }
        case (4): // Square
        {
            int s = 0;
            cout << "Enter Side Length:";
            cin >> s;

            P[i] = new Square(s);
            break;
        }
        }
    }
    GeoShape g(P);
    cout << "Total Area = " << g.TotalArea(nShapes);
    delete[] P;

    return 0;
}
