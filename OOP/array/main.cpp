#include <iostream>
using namespace std;
int main() {
    char name[20] =  {'a','b','c'};
    cout << "The Default value = "<< name <<endl;
    cout << "Enter Your Name   ";
    cin >> name;
    cout << "Your Name is : "<< name <<endl;
    cout << name;
    return 0;
}
