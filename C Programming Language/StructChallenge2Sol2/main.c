#include <stdio.h>
#include <stdlib.h>

struct Item
{
    char* pItemName;
    int quantity;
    float price;
    float amount;
};
void readItem (struct Item* pItem);
void printItem (struct Item* pItem);
int main()
{
    struct Item apple ;
    struct Item* pItem;

    pItem = &apple;
    pItem->pItemName = (char *) malloc(20* sizeof(char));

    if (pItem->pItemName) { // ( pItem->pItemName != NULL )
            readItem(pItem);
            printItem(pItem);
            free(pItem->pItemName);
    }

    return 0;
}
void readItem (struct Item* pItem)
{
    printf("Enter the Product Name:  ");
    scanf("%s",pItem->pItemName);

    printf("Enter the Product Quantity:  ");
    scanf("%d",&pItem->quantity);

    printf("Enter the Product Price:  ");
    scanf("%f",&pItem->price);

    pItem->amount = (float)(pItem->quantity * pItem->price);
};
void printItem (struct Item* pItem)
{

    printf("Product Name: %s \n", pItem->pItemName ); // *(pItem->pItemName)

    printf("Enter the Product Quantity:%d \n",pItem->quantity);

    printf("Enter the Product Price:%0.2f \n",pItem->price);

    printf("Enter the Product Amount:%0.2f \n",pItem->amount);

};
