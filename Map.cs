class Map{
    int[] location = {1,3,2,5,2,3,1,0};
    
    bool firstTime1 = true;
    bool firstTime3 = true;
    bool firstTime2 = true;
    bool mapDone = false;
    int y = 0;

    int startValue = 28; 
    int gapValue = 0;    
    int gapValue2 = 0; 
    public Map()
    {
        while(mapDone == false){
    
            string startIndent = new string(' ', startValue);
    
            // --- 1. TOPPEN AF FIRKANTERNE ---
            Console.Write(startIndent); 
            for (int x = 0; x < location[y]; x++){
                if (x > 0) {
                    // Hvis det er rækken med 5, deler vi mellemrummene op
                    if (location[y] == 5) {
                        int nuværendeGap = (x == 1 || x == 4) ? gapValue : gapValue2;
                        Console.Write(new string(' ', nuværendeGap));
                    } else {
                        Console.Write(new string(' ', gapValue));
                    }
                }
                Console.Write(" _____ ");
            }
            Console.WriteLine("");
    
            // --- 2. MIDTEN AF FIRKANTERNE ---
            Console.Write(startIndent); 
            for (int a = 0; a < location[y]; a++){
                if (a > 0) {
                    if (location[y] == 5) {
                        int nuværendeGap = (a == 1 || a == 4) ? gapValue : gapValue2;
                        Console.Write(new string(' ', nuværendeGap));
                    } else {
                        Console.Write(new string(' ', gapValue));
                    }
                }
                Console.Write("|     |");
            }
            Console.WriteLine("");
    
            // --- 3. BUNDEN AF FIRKANTERNE ---
            Console.Write(startIndent); 
            for (int z = 0; z < location[y]; z++){
                if (z > 0) {
                    if (location[y] == 5) {
                        int nuværendeGap = (z == 1 || z == 4) ? gapValue : gapValue2;
                        Console.Write(new string(' ', nuværendeGap));
                    } else {
                        Console.Write(new string(' ', gapValue));
                    }
                }
                Console.Write("|_____|");
            }
            
            Console.WriteLine("");
            y++;
   
            // --- SWITCH LOGIK ---
            switch(location[y]) 
            {
                case 1:
                    startValue = 28; 
                    gapValue = 0;  
                    break;
                case 2:
                    startValue = 10; 
                    gapValue = 29; 
                    break;
                case 3:
                    startValue = 20; 
                    gapValue = 1; 
                    break;
                case 5:
                    startValue = 1;  
                    gapValue = 2;    
                    gapValue2 = 11;
                    break;    
                default:
                    mapDone = true;
                    break;
            }
        }
    }
}