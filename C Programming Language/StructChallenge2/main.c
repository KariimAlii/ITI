#include <stdio.h>
#include <stdlib.h>

struct Item
{
    char* pItemName;
    int quantity;
    float price;
    float amount;
};
void readItem (struct Item product);
void printItem (struct Item product);
int main()
{
    struct Item apple ;
    apple.pItemName = (char *) malloc(20* sizeof(char));

    readItem(apple);
    printItem(apple);
    return 0;
}
void readItem (struct Item product)
{
    //printf("Enter the Product Name:  ");
    //scanf("%s",product.pItemName);

    printf("Enter the Product Quantity:  ");
    scanf("%d",&product.quantity);

    printf("Enter the Product Price:  ");
    scanf("%f",&product.price);

    product.amount = product.quantity * product.price;
};
void printItem (struct Item product)
{
    //printf("Product Name:  ");
    //printf("%s \n",*(product.pItemName));

    printf("Enter the Product Quantity:  ");
    printf("%d \n",product.quantity);

    printf("Enter the Product Price:  ");
    printf("%f \n",product.price);
};
