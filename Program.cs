// 변수
int answer; 
string select;
bool check; 
int level = 1;
string name = "르타";
string job = "전사";
int atk = 10;
int def = 5;
int hp = 100;
int gold = 20000;
int itemprice = 0;
int itemnum = 1;
int itematk = 0;
int itemdef = 0;

//아이템 목록
string[,] shopitem = new string[4,6];
shopitem[0, 0] = "수련자 갑옷";
shopitem[0, 1] = "무쇠 갑옷";
shopitem[0, 2] = "스파르타의 갑옷";
shopitem[0, 3] = "낡은 검";
shopitem[0, 4] = "청동 도끼";
shopitem[0, 5] = "스파르타의 창";
shopitem[1, 0] = "1000 G";
shopitem[1, 1] = "2000 G";
shopitem[1, 2] = "3500 G";
shopitem[1, 3] = "600 G";
shopitem[1, 4] = "1500 G";
shopitem[1, 5] = "3000 G";
shopitem[2, 0] = "5";
shopitem[2, 1] = "9";
shopitem[2, 2] = "15";
shopitem[2, 3] = "2";
shopitem[2, 4] = "5";
shopitem[2, 5] = "7";
shopitem[3, 0] = "수련에 도움을 주는 갑옷입니다.";
shopitem[3, 1] = "무쇠로 만들어져 튼튼한 갑옷입니다.";
shopitem[3, 2] = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.";
shopitem[3, 3] = "쉽게 볼 수 잇는 낡은 검 입니다.";
shopitem[3, 4] = "어디선가 사용됐던거 같은 도끼입니다.";
shopitem[3, 5] = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.";
string[,] myitem = new string[6,6];

do
{
    do
    {
        
        Console.WriteLine();
        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("1. 상태 보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine("3. 상점");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        select = Console.ReadLine();

        check = int.TryParse(select, out answer); //문자인지 구분
        if (check)
        {
            if (answer < 0 || answer > 3)
            {
                Console.WriteLine("잘못된 입력입니다.");  
            }
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
        }
        
    }
    while (!check || (answer < 0 || answer > 3)); //메인화면

    switch (answer)
    {
        case 1:
            {
                do
                {
                    itematk = 0;
                    itemdef = 0;
                    status();
                    select = Console.ReadLine();
                }
                while (select != "0");
                break;
            } //상태창 선택지
            
        case 2: 
            {
                do
                {
                    
                    inventory();
                    select = Console.ReadLine();
                    if (select == "1")
                    {
                        do
                        { 
                            itemnum = 1;
                            equipitem();
                            select = Console.ReadLine();
                            if(select != "0")
                            {
                                check = int.TryParse (select, out answer);
                                if(!check)
                                {
                                    Console.WriteLine("잘못된 입력입니다.");
                                }
                                else if (answer < 0 || answer > 6)
                                {
                                    Console.WriteLine("잘못된 입력입니다.");
                                }
                                else if (answer > 0 && answer <= 6)
                                {

                                    for (int i = 0; i < 6; i++)
                                    {
                                        
                                        if (select == myitem[4, i] && (myitem[5, i] != "[E]"))
                                        {
                                            Console.WriteLine("장비가 장착되었습니다.");
                                            myitem[5, i] = "[E]";
                                            break;
                                        }
                                        else if (select == myitem[4, i] && (myitem[5, i] == "[E]"))
                                        {
                                            Console.WriteLine("장비가 해제되었습니다.");
                                            myitem[5, i] = "";
                                            break;
                                        }
                                        else if (shopitem[1, i] != "구매완료" && i == 5)
                                        {
                                            Console.WriteLine("잘못된 입력입니다.");
                                            break;
                                        }

                                    }
                                }
                                
                            }
                        }
                        while(select != "0");
                    }
                }
                while (select != "0");
                break;
            } // 인벤토리 선택지

        case 3:
            {
                do
                {
                    shop();
                    select = Console.ReadLine();
                    
                    if(select ==  "1")
                    {
                        do
                        {
                            
                            buyshop();
                            select = Console.ReadLine();
                            check = int.TryParse (select, out answer);
                            
                            if (!check)
                            {
                                Console.WriteLine("잘못된 입력입니다.");
                            }

                            if(answer < 0 || answer > 6)
                            {
                                Console.WriteLine("잘못된 입력입니다.");
                            }
                            else if (answer == 0)
                            {
                                break;
                            }
                            else if (answer > 0 && answer <= 6)
                            {
                                if (shopitem[1, answer -1] == "구매완료")
                                {
                                    Console.WriteLine("이미 구매한 아이템입니다.");
                                    continue;
                                }
                                buyitem();
                            }
                            
                           
                        }
                        while(select != "0");
                    }// 상점 - 구매창
                    
                }
                while (select != "0");
                break;
            } //상점 선택지
    } //메뉴 선택시

}
while (true);// 프로젝트 반복문


void status()
{
    Console.WriteLine();
    Console.WriteLine("상태 보기");
    Console.WriteLine("캐릭터의 정보가 표시됩니다.");
    Console.WriteLine();
    if(level < 10)
    {
        Console.WriteLine("Lv. "+"0" + level);
    }
    else
    {
        Console.WriteLine("Lv. " + level);
    }
    Console.WriteLine(name + "( " + job +" )");
    
    
    if (myitem[5, 3] == "[E]")
    {
        itematk += int.Parse(myitem[2, 3]);
        
    }
    if (myitem[5, 4] == "[E]")
    {
        itematk += int.Parse(myitem[2, 4]);

    }
    if (myitem[5, 5] == "[E]")
    {
        itematk += int.Parse(myitem[2, 5]);

    }
    if(itematk > 0)
    {
        Console.WriteLine("공격력 : " + (atk + itematk) + " ( " + "+" + itematk + " )");
    }
    else if(itematk == 0)
    {
        Console.WriteLine("공격력 : " + atk);
    }// 공격력 출력
    
    if (myitem[5, 0] == "[E]")
    {
        itemdef += int.Parse(myitem[2, 0]);

    }
    if (myitem[5, 1] == "[E]")
    {
        itemdef += int.Parse(myitem[2, 1]);

    }
    if (myitem[5, 2] == "[E]")
    {
        itemdef += int.Parse(myitem[2, 2]);

    }
    if (itemdef > 0)
    {
        Console.WriteLine("방어력 : " + (def + itemdef) + " ( " + "+" + itemdef + " )");
    }
    else if (itemdef == 0)
    {
        Console.WriteLine("공격력 : " + def);
    }//방어력 출력

    Console.WriteLine("체 력 : " + hp);
    Console.WriteLine("Gold : " + gold + " " + "G");
    Console.WriteLine();
    Console.WriteLine("0. 나가기");
    Console.WriteLine();
    Console.WriteLine("원하시는 행동을 입력해주세요");
}//상태창

void inventory()
{
    Console.WriteLine();
    Console.WriteLine("인벤토리");
    Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
    Console.WriteLine();
    Console.WriteLine("[아이템 목록]");
    Console.WriteLine("");
    for(int i = 0; i < 6; i++)
    {
        if (shopitem[1, i] == "구매완료")
        {
            if (i < 3)
            {
                Console.WriteLine("- " + myitem[5, i] + myitem[0, i] + " | " + "방어력 +" + myitem[2, i] + " | " + myitem[3, i]);
            }
            else if (i >= 3)
            {
                Console.WriteLine("- " + myitem[5, i] + myitem[0, i] + " | " + "공격력 +" + myitem[2, i] + " | " + myitem[3, i]);
            }
        } 
    }
    Console.WriteLine();
    Console.WriteLine("1. 장착 관리");
    Console.WriteLine("0. 나가기");
    Console.WriteLine();
    Console.WriteLine("원하시는 행동을 입력해주세요.");
}//인벤토리

void shop()
{

    Console.WriteLine();
    Console.WriteLine("상점");
    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
    Console.WriteLine();
    Console.WriteLine("[보유 골드]");
    Console.WriteLine(gold + " G");
    Console.WriteLine();
    Console.WriteLine("[아이템 목록]");
    Console.WriteLine();
    Console.WriteLine("- " + shopitem[0, 0] + "     | " + "방어력 +" + shopitem[2, 0] + "  | " + shopitem[3, 0] + "\t\t\t" + " | " + shopitem[1, 0]);
    Console.WriteLine("- " + shopitem[0, 1] + "       | " + "방어력 +" + shopitem[2, 1] + "  | " + shopitem[3, 1] + "\t\t" + " | " + shopitem[1, 1]);
    Console.WriteLine("- " + shopitem[0, 2] + " | " + "방어력 +" + shopitem[2, 2] + " | " + shopitem[3, 2] + "| " + shopitem[1, 2]);
    Console.WriteLine("- " + shopitem[0, 3] + "         | " + "공격력 +" + shopitem[2, 3] + "  | " + shopitem[3, 3] + "\t\t\t" + " | " + shopitem[1, 3]);
    Console.WriteLine("- " + shopitem[0, 4] + "       | " + "공격력 +" + shopitem[2, 4] + "  | " + shopitem[3, 4] + "\t\t" + " | " + shopitem[1, 4]);
    Console.WriteLine("- " + shopitem[0, 5] + "   | " + "공격력 +" + shopitem[2, 5] + "  | " + shopitem[3, 5] +  "| " + shopitem[1, 5]);
    Console.WriteLine();
    Console.WriteLine("1. 아이템 구매");
    Console.WriteLine("0. 나가기");
    Console.WriteLine();
    Console.WriteLine("원하시는 행동을 입력해주세요.");

}//상점
void buyshop()
{
    Console.WriteLine();
    Console.WriteLine("상점 - 아이템 구매");
    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
    Console.WriteLine();
    Console.WriteLine("[보유 골드]");
    Console.WriteLine(gold + " G");
    Console.WriteLine();
    Console.WriteLine("[아이템 목록]");
    Console.WriteLine();
    Console.WriteLine("- 1. " + shopitem[0, 0] + "     | " + "방어력 +" + shopitem[2, 0] + "  | " + shopitem[3, 0] + "\t\t\t" + " | " + shopitem[1, 0]);
    Console.WriteLine("- 2. " + shopitem[0, 1] + "       | " + "방어력 +" + shopitem[2, 1] + "  | " + shopitem[3, 1] + "\t\t\t" + " | " + shopitem[1, 1]);
    Console.WriteLine("- 3. " + shopitem[0, 2] + " | " + "방어력 +" + shopitem[2, 2] + " | " + shopitem[3, 2] + "\t"+" | " + shopitem[1, 2]);
    Console.WriteLine("- 4. " + shopitem[0, 3] + "         | " + "공격력 +" + shopitem[2, 3] + "  | " + shopitem[3, 3] + "\t\t\t" + " | " + shopitem[1, 3]);
    Console.WriteLine("- 5. " + shopitem[0, 4] + "       | " + "공격력 +" + shopitem[2, 4] + "  | " + shopitem[3, 4] + "\t\t" + " | " + shopitem[1, 4]);
    Console.WriteLine("- 6. " + shopitem[0, 5] + "   | " + "공격력 +" + shopitem[2, 5] + "  | " + shopitem[3, 5] + "\t"+" | " + shopitem[1, 5]);
    Console.WriteLine();
    Console.WriteLine("0. 나가기");
    Console.WriteLine();
    Console.WriteLine("원하시는 행동을 입력해주세요.");


}//구매창
void buyitem()
{
    shopitem[1, answer - 1] = shopitem[1, answer - 1].Replace("G", "");
    itemprice = int.Parse(shopitem[1, answer - 1]);
    
    if(gold >= itemprice)
    {
        Console.WriteLine("구매를 완료했습니다.");
        for(int i = 0; i < 4;  i++)
        {
            myitem[i, answer - 1] = shopitem[i, answer - 1];
        }

        gold = gold - itemprice;
        shopitem[1, answer - 1] = "구매완료";
    } //아이템 구매성공
    else if(gold < itemprice)
    {
        Console.WriteLine("Gold 가 부족합니다.");
        shopitem[1, answer - 1] += "G";
    }
    
}//아이템 구매과정

void equipitem ()
{
    Console.WriteLine();
    Console.WriteLine("인벤토리");
    Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
    Console.WriteLine();
    Console.WriteLine("[아이템 목록]");
    Console.WriteLine("");
    
    for (int i = 0; i < 6; i++)
    {
        
        if (shopitem[1, i] == "구매완료")
        {
            
            if (itemnum < 7)
            {
                myitem[4, i] = itemnum.ToString();

                if (i < 3)
                {
                    Console.WriteLine("- " + myitem[4, i] + ". " + myitem[5, i] + myitem[0, i] + " | " + "방어력 +" +myitem[2, i] + " | " + myitem[3, i]);
                }
                else if(i >= 3)
                {
                    Console.WriteLine("- " + myitem[4, i] + ". " + myitem[5, i] + myitem[0, i] + " | " + "공격력 +" + myitem[2, i] + " | " + myitem[3, i]);
                }
                    itemnum++;
            }
            
        }
    }
    Console.WriteLine();
    Console.WriteLine("0. 나가기");
    Console.WriteLine();
    Console.WriteLine("원하시는 행동을 입력해주세요");
}// 장착관리
