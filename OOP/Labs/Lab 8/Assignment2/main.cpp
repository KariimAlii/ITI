#include <iostream>
using namespace std;

class Point3D
{
    int x, y, z;

public:
    Point3D() { x = y = z = 0; }
    Point3D(int x , int y , int z)
    {
        this->x = x;
        this->y = y;
        this->z = z;
    }
    void SetX(int x) {this->x = x;}
    void SetY(int y) {this->y = y;}
    void SetZ(int z) {this->z = z;}

    int GetX() {return x;}
    int GetY() {return y;}
    int GetZ() {return z;}

friend ostream& operator << (ostream& out , Point3D& p);
friend istream& operator >> (istream& in , Point3D& p);
};


int main()
{
    Point3D Pt(3,4,5);
    cin >> Pt;
    cout << Pt;
    return 0;
}
ostream& operator<< (ostream& out , Point3D& p)
{
    out << "X = " << p.x <<endl;
    out << "Y = " << p.y <<endl;
    out << "Z = " << p.z <<endl;
    return out; // return cout;
}
istream& operator>> (istream& in , Point3D& p)
{
    cout << "Enter The Point X Coordiante:";
    in >> p.x;
    cout << "Enter The Point Y Coordiante:";
    in >> p.y;
    cout << "Enter The Point Z Coordiante:";
    in >> p.z;
    return in; // return cin;
}