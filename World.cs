/* World class for modeling the entire in-game world
 */

class World
{
  Space square;
  
  Player? player;
  
  
  public World(Player player)
  {
      this.player = player; 
    List<string> schoolDilemma = new List<string>();
    schoolDilemma.Add("Principal: Hello there, "+ player.GetName() +" Sorry to bother you but we have a school meeting at the hall today and maybe you could participate ");
    schoolDilemma.Add(player.GetName() + ": And what were you thinking should do ");
    schoolDilemma.Add("Principal: If you just had some inspirational words to motivate the young people, that will be all we need from you. What do you say?");
   
    List<string> nursingDilemma = new List<string>();
    nursingDilemma.Add(player.GetName() + " Hello everyone, looks cosy in here ");
    nursingDilemma.Add("Staff: didn't expect you here " + player.GetName() + ". What can we do for you ");
    nursingDilemma.Add(player.GetName() + ": Just walking around the city and looking for people who needs some help");
    nursingDilemma.Add("Staff: Actually, you can help serve lunch for the elderly. Don't know if you would like to help with that? ");
    
    List<string> hospitalDilemma = new List<string>();
    hospitalDilemma.Add("Staff: Hello "+ player.GetName() +", what a surprise to see you here. in the wards. Are you out checking up on the local healthcare? ");
    hospitalDilemma.Add(player.GetName() + "Just walking around and enjoying the city, before the election.");
    hospitalDilemma.Add("Staff: I know you properly are very busy, but do you have a couple minuts to help us. We are a bit short-handed in the children's section today. If you could read a short story for them it would help us alot? Will you do that for us? ");
    
    List<string> festivalDilemma = new List<string>();
    festivalDilemma.Add("Festival organizer: Oh MR." + player.GetName() + " am i glad to see you. ");
    festivalDilemma.Add(player.GetName() + ": always a pleasure, I was just in the neighborhood and thought i would swing by to see how the progress is going with the festival. ");
    festivalDilemma.Add("Festival organizer: Well " + player.GetName() + ", we are trying to get accessibility ramps throughout the festival, but it will put us over the budget. ");
    festivalDilemma.Add(player.GetName() + ": ohh Im so sorry to hear, is there anything i could do. ");
    festivalDilemma.Add("Festival organizer: Well the cityhall had always donated to the festival, but this year the money is going to a lunch for you and the other politicians. If maybe you could find it in your heart to get the donation back we could arrange a beautiful lunch here, in the heart of the city and community");

    
    List<string> shelterDilemma = new List<string>();
    shelterDilemma.Add("Staff: Oh, hello " + player.GetName() + ". We didn't expect you to drop by the shelter today. What brings you here? ");
    shelterDilemma.Add(player.GetName() + "Just walking around the city and looking for people who needs some help.");
    shelterDilemma.Add("Staff: To be honest, we just received a big donation of warm winter clothes, but we lack hands to sort them out to the residents. Would you be willing to help us with that? ");
    
    
    List<string> sportDilemma = new List<string>();
    sportDilemma.Add("Club Volunteer: Hey, we're short on volunteers for Saturday's youth tournament. Could you give us a hand?");
    sportDilemma.Add(player.GetName() + "I've got other things to do. What's in it for me? ");
    sportDilemma.Add("Club Volunteer: Not much, honestly. The club runs on volunteers. The more people help out, the more activities we can offer the kids.");
    sportDilemma.Add(player.GetName() + "So I'd just be helping the community?");
    sportDilemma.Add("Club Volunteer: Exactly. A few hours of your time means dozens of children get a great day of sports.");
    sportDilemma.Add("Club Volunteer: Can you help us, and volunteer at the tournament? ");
    
    List<string> constructionDilemma = new List<string>();
    constructionDilemma.Add("Construction Foreman: Glad you're here. We're expecting a safety inspection tomorrow, and there are a few issues that still need fixing.");
    constructionDilemma.Add(player.GetName() + ": If they're not fixed, won't that be a problem?");
    constructionDilemma.Add("Construction Foreman: Maybe. But delays cost money. If the inspector doesn't look too closely, the project stays on schedule.");
    constructionDilemma.Add(player.GetName() + ": And what do you want from me?");
    constructionDilemma.Add("Construction Foreman: Put in a good word. Convince them there's no need for a thorough inspection. You may even get a penthouse apartment. Who knows?");
    constructionDilemma.Add(player.GetName() + "  Even if the site isn't fully compliant?");
    constructionDilemma.Add("Construction Foreman: It'll be fixed eventually. Why hold up the whole project over a few minor details?");
    constructionDilemma.Add("Construction Foreman: Could you use your influence to reduce the scrutiny of the forthcoming inspection?");
    
    List<string> farmDilemma = new List<string>();
    farmDilemma.Add("Farm Owner: Good to see you. Business has been tough lately. I could use some help getting my produce into the town's schools.");
    farmDilemma.Add(player.GetName() + "Don't they already have a supplier?");
    farmDilemma.Add("Farm Owner: They do, but contracts come up for renewal soon. A recommendation from the right person could make a difference.");
    farmDilemma.Add(player.GetName() + "And what would I get in return?");
    farmDilemma.Add("Farm Owner: Let's just say you'd never have to pay for vegetables again. A small favor for a local farmer.");
    farmDilemma.Add(player.GetName() + "So you'd rather have connections decide than the best offer?");
    farmDilemma.Add("Farm Owner: Business is business. Sometimes you need a little help.");
    farmDilemma.Add("Farm Owner: Will you use your influence to help me get the contract?");
    
    List<string> companyDilemma = new List<string>();
    companyDilemma.Add("Company Manager: Hey, I need a favor. We're bidding on a municipal contract, and a good word from someone in the city would really help.");
    companyDilemma.Add(player.GetName() + ": You mean put in a recommendation?");
    companyDilemma.Add("Company Manager: Nothing official. Just let people know we're the \"right choice.\" If we get the contract, there could be something in it for you.");
    companyDilemma.Add(player.GetName() + ": So you want me to influence the decision?");
    companyDilemma.Add("Company Manager: Let's just say we'd both benefit. The process is slow enough already. ");
    companyDilemma.Add("Company Manager: Could you help the company secure the contract through your personal connections?");
    
    List<string> bankDilemma = new List<string>();
    bankDilemma.Add("Bank manager: Well hello there " + player.GetName() + ", i have a proposal for you. Theoretically, what would you say if I could give you access to a secret account with 500.000 dkk as a campaign contribution. ");
    bankDilemma.Add(player.GetName() + ": Well, no one would give the new town politician that amount of money, so I sound like you want something in return. ");
    bankDilemma.Add("Bank Manager: you are a smart man, I like that. I know after this election the city is going to make some large investments that requires some loans. All I ask for you is to consider my bank as the bank to loan that money from, even though we might not have the best terms regarding the citizens of the city. ");
    
    
    List<string> billionaireDilemma = new List<string>();
    billionaireDilemma.Add("Billionaire: I thought my mind was playing a trick with me, Mr. "+ player.GetName()+ ", what are you doing here. ");
    billionaireDilemma.Add(player.GetName() +": oh just making my way around the city making some connections before the election, you know, helping the people i serve. ");
    billionaireDilemma.Add("Bilionaire: well am i glad you said that. You see, I'm in a bit of a pickle. I've been planning to build a small get-away cabin in the woods like a vacation house, but close to home.  ");
    billionaireDilemma.Add(player.GetName() +": Sounds amazing, it would certainly increase the interest newcomers would have in the city. ");
    billionaireDilemma.Add("Bilionaire: Well, there is just one small problem. I want to build it in the forest but someone a long time ago decided it was a protected property forest so i can't build it there. Let's just say that if the forest is no longer protected, you might find a cabin with your name on the mailbox. ");
    
    List<string> lawyerDilemma = new List<string>();
    lawyerDilemma.Add("Lawyer: Welcome MR. "+ player.GetName() +" what brings you to my humble offices");
    lawyerDilemma.Add(player.GetName() +": oh i wouldn't say humble, your place is massive, with beautiful offices, do you rent them out, I've been looking around. ");
    lawyerDilemma.Add("Lawyer: Well we want to, you know to give something more to the city, but we run into a problem. You see prosecuting everyone for everything takes a lot of associates and space. ");
    lawyerDilemma.Add(player.GetName() +": oh i wouldn't say humble, your place is massive, with beautiful offices, do you rent them out, I've been looking around. But if we could get our hands on the bottom floor from the people at rødekors we could expand. You know, I have some leverage over some of them and with a little help from you we could kick them out and find a nice office for you. ");

    
    
    Space square = new Space("Town Square", "You are now in the middle of the city", new Dilemma(schoolDilemma, new Score (10,10,10)));
    Space community = new Space("Community Neighborhood");
    Space industrial = new Space("Industrial Area");
    Space finance = new Space("Finance Square");
    Space service = new Space("Public service");
    Space festival = new Space("Local Festival","", new Dilemma(festivalDilemma, new Score (10,10,10)));
    Space shelter = new Space("Homeless Shelter","", new Dilemma(shelterDilemma, new Score (10,10,10)));
    Space sport = new Space("Local Associations", "Welcome to the Local Associations! We're all very excited to host you!" , new Dilemma(sportDilemma, new Score (10,10,10)));
    Space company = new Space("Private Company", "Welcome to the Private Company! Do you want to get down to buisness?", new Dilemma(companyDilemma, new Score (10,10,10)));
    Space farm = new Space("Local Farm", "Welcome to the Local Farm! Would you like some of my produce? Could give you a great discount... for an exchange in services...", new Dilemma(farmDilemma, new Score (10,10,10)));
    Space construction = new Space("Construction Site", "Welcome to the Construction Site! Could you give us a hand?", new Dilemma(constructionDilemma, new Score (10,10,10)));
    Space bank = new Space("Bank","", new Dilemma(bankDilemma, new Score (10,10,10)));
    Space billionaire = new Space("Local Billionaire","", new Dilemma(billionaireDilemma, new Score (10,10,10)));
    Space lawyer = new Space("Law Firm", "",new Dilemma(lawyerDilemma, new Score (10,10,10)));
    Space hospital = new Space("Hospital", "",new Dilemma(hospitalDilemma, new Score (10,10,10)));
    Space nursing = new Space("Nursing Home","", new Dilemma(nursingDilemma, new Score (10,10,10)));
    Space school = new Space("School","", new Dilemma(schoolDilemma, new Score (10,10,10)));

    //edge from square
    square.AddEdge("north", industrial);
    square.AddEdge("east", community);
    square.AddEdge("south", service);
    square.AddEdge("west", finance);

    //egde from industrial to room
    industrial.AddEdge("company", company);
    industrial.AddEdge("farm", farm);
    industrial.AddEdge("construction", construction);
    industrial.AddEdge("back", square);
    //edge from room to industrial
    company.AddEdge("back", industrial);
    farm.AddEdge("back", industrial);
    construction.AddEdge("back", industrial);

    //edge from community to room
    community.AddEdge("sport", sport);
    community.AddEdge("shelter", shelter);
    community.AddEdge("festival", festival);
    community.AddEdge("back", square);
    //edge from room to community
    sport.AddEdge("back", community);
    shelter.AddEdge("back", community);
    festival.AddEdge("back", community);

    //edge from service to room
    service.AddEdge("school", school);
    service.AddEdge("nursing", nursing);
    service.AddEdge("hospital", hospital);
    service.AddEdge("back", square);
    //edge from room to service
    school.AddEdge("back", service);
    nursing.AddEdge("back", service);
    hospital.AddEdge("back", service);

    //edge from finance to room
    finance.AddEdge("bank", bank);
    finance.AddEdge("billionaire", billionaire);
    finance.AddEdge("lawyer", lawyer);
    finance.AddEdge("back", square);
    //edge from room to finance
    bank.AddEdge("back", finance);
    billionaire.AddEdge("back", finance);
    lawyer.AddEdge("back", finance);



    this.square = square;
  }

  public Space GetEntry()
  {
    return square;
  }
  
  public void SetPlayer(Player player)
  {
     this.player = player;
  }
  
}

