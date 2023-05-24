#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
int main() {


    fstream file;
    file.open("binary.bin" , ios::in | ios::binary );
    if (file.is_open())
    {
        int onePrice;

        while (file.read( ( char* ) &onePrice , sizeof(onePrice) )) {
            cout << onePrice <<endl;
        }
        file.close();
    }

    return 0;
}




//=========== Read from a binary file =============//
//int main() {
//
//
//    fstream file;
//    file.open("binary.bin" , ios::in | ios::binary );
//    if (file.is_open())
//    {
//        int onePrice;
//
//        file.read( ( char* ) &onePrice , sizeof(onePrice) );
//        cout << onePrice;
//        file.close();
//    }
//
//    return 0;
//}


//=========== Write to binary file =============//
//int numbers[] = {1'000'000,2'000'000,3'000'000};
//fstream file;
//file.open("binary.bin",ios::out | ios::binary);
//if (file.is_open())
//{
//file.write ( reinterpret_cast< char* > (&numbers) , sizeof(numbers) );
//file.close();
//}


//#include <iostream>
//#include <limits>
//using namespace std;
//void check (int &number , string prompt , string errorMessage) {
//
//    while (true)
//    {
//        cout << prompt;
//
//        cin >> number;
//
//        if (cin.fail() || (number > 10 && number < 20) )
//        {
//            cout << errorMessage <<endl;
//            cin.clear();
//            cin.ignore(numeric_limits<streamsize>::max(),'\n');
//        }
//        else
//        {
//            cin.ignore(numeric_limits<streamsize>::max(),'\n');
//            break;
//        }
//    }
//}
//int main() {
//    int first , second;
//    check(first ,"First:", "Please enter a valid number!");
//    check(second ,"Second:", "Please enter a valid number!");
//    cout << "You entered " << first << " and " << second;
//    return 0;
//}


//ofstream file;
//file.open("data.csv");

//if (file.is_open())
//{
//// CSV : comma separated values
//file << "id,title,year\n"
//<< "1 , Terminator 1 , 1796\n"
//<< "2 , Terminator 2 , 1994\n"
//<< "3 , Terminator 2 , 2006\n";
//file.close();
//}

//int main() {
//    ifstream file;
//    file.open("data.csv");
//    if ( file.is_open() )
//    {
////        char str[30];
//        string str;
//        while(!file.eof()) {
//            getline(file,str , ',');
//            cout << str <<endl;
//        }
//        file.close();
//    }
//    return 0;
//}



//BINARY
//==========

//========TEXT==========//
//file.open("binary.txt",ios::out);
//if (file.is_open())
//{
//for (int num : numbers) {
//file << num <<endl;
//}
//file.close();
//}