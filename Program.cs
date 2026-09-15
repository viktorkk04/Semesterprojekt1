int y= 0;
int x= 0;

int mapSize = 6;
string mellemrum = "";

for (y = 1; y <= mapSize; y++){
    // Reserverer 140 tegn
    Console.Write($"{mellemrum,140}");
    //Console.Write(y*1);
    for (x = 1; x <= mapSize; x++){
        Console.Write("|");
        Console.Write("-");
    }   
    Console.WriteLine("|");
}
