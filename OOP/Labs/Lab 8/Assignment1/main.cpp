#include <iostream>
#include <fstream>
using namespace std;

class Point3D
{
    int x, y, z;

public:
    Point3D() { x = y = z = 0; }
    Point3D(int x, int y, int z)
    {
        this->x = x;
        this->y = y;
        this->z = z;
    }
    void SetX(int x) { this->x = x; }
    void SetY(int y) { this->y = y; }
    void SetZ(int z) { this->z = z; }

    int GetX() { return x; }
    int GetY() { return y; }
    int GetZ() { return z; }

    friend ostream &operator<<(ostream &out, Point3D &p);
    friend istream &operator>>(istream &in, Point3D &p);
};

int main()
{
    Point3D Pt1(1, 2, 3), Pt2(0, 0, 0);
    fstream myFile;
    //========Writing to Text File==========//
    myFile.open("myFile.txt", ios::out);
    if (myFile.is_open())
    {
        myFile << Pt1;
        myFile.close();
    }
    //========Reading from Text File==========//

    myFile.open("myFile.txt", ios::in);
    if (myFile.is_open())
    {
        myFile >> Pt2;
        cout << "***Pt2 changed to***:" <<endl << Pt2;
        myFile.close();
    }

    //========Writing to Binary File==========//
    Point3D Pt3(4, 5, 6), Pt4(10, 20, 30);
    myFile.open("myFile.bin", ios::out | ios::binary);
    if (myFile.is_open())
    {
        myFile.write( (char*) &Pt3 , sizeof(Point3D));
        myFile.close();
    }
    //========Reading from Binary File==========//
    myFile.open("myFile.bin", ios::in | ios::binary);
    if (myFile.is_open())
    {
        myFile.read ( (char*) &Pt4 , sizeof(Point3D));
        cout <<"***Pt4 changed to***" <<endl << Pt4;
        myFile.close();
    }
    return 0;
}
ostream &operator<<(ostream &out, Point3D &p)
{
    out << p.x << endl;
    out << p.y << endl;
    out << p.z << endl;
    return out;
}
istream &operator>>(istream &in, Point3D &p)
{
    in >> p.x;
    in >> p.y;
    in >> p.z;
    return in;
}