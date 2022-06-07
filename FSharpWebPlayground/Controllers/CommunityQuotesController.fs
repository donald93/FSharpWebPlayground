namespace FSharpWebPlayground.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open FSharpWebPlayground

[<ApiController>]
[<Route("[controller]")>]
type CommunityQuotesController (logger : ILogger<CommunityQuotesController>) =
    inherit ControllerBase()



    let characters = 
        [|
            { Name = "Abed Nadir"; Actor = "Danny Pudi" }
            { Name = "Jeff Winger"; Actor = "Joel McHale" };
            { Name = "Annie Edison"; Actor = "Alison Brie" };
            { Name = "Troy Barnes"; Actor = "Donald Glover" };
            { Name = "Pierce Hawthorne"; Actor = "Chevy Chase" };
            { Name = "Shirley Bennett"; Actor = "Yvette Nicole Brown" };
            { Name = "Britta Perry"; Actor = "Gillian Jacobs" };
            { Name = "Ben Chang"; Actor = "Ken Jeong" };
            { Name = "Dean Pelton"; Actor = "Jim Rash" };
        |]

        //https://www.reddit.com/r/community/comments/3285he/the_ultimate_community_quote_list/

    let quotes =
        [|
            {Quote = "You are all better than you think you are, you are just designed not to believe it when you hear it from yourself"; Character = "Jeff Winger"}
            {Quote = "Harrison Ford is irradiating our testicles with microwave satellite transmissions!"; Character = "Jeff Winger"}
            {Quote = "Doing more than the minimum amount of work is my definition of failing."; Character = "Jeff Winger"}
            {Quote = "I see your value now."; Character = "Jeff Winger"}
            {Quote = "To me, religion is like Paul Rudd. I see the appeal, and I would never take it away from anyone, but I would also never stand in line for it."; Character = "Jeff Winger"}
            {Quote = "The next person that offers me charity or pity will be mentioned, by name, in my suicide note."; Character = "Jeff Winger"}
            {Quote = "Let's do what people do. Let's get a house we can't afford and a dog that makes us angry."; Character = "Jeff Winger"}
            {Quote = "We're the only species on earth that observes shark week."; Character = "Jeff Winger"}
            {Quote = "TV's the best dad there is. TV never came home drunk, Tv never forgot me at the zoo, TV never abused and insulted me.. unless you count Cop Rock."; Character = "Jeff Winger"}
            {Quote = "I don't have an ego. My Facebook photo is a landscape."; Character = "Jeff Winger"}
            {Quote = "Never listen to Pierce."; Character = "Jeff Winger"}
            {Quote = "Look at me. It's clear to you that I am awesome, but I can never admit that, because that would make me an ass."; Character = "Jeff Winger"}
            {Quote = "It's called chemistry, I have it with everybody!"; Character = "Jeff Winger"}
            {Quote = "What am I not good at"; Character = "Jeff Winger"}
            {Quote = "If crazy people can't be at Greendale, then where are we supposed to go?"; Character = "Jeff Winger"}
            {Quote = "Haul it, ball it, never call it. Girls are objects."; Character = "Jeff Winger"}
            {Quote = "It's a locomotive that runs on us!"; Character = "Jeff Winger"}
            {Quote = "I discovered at a very early age that if I talked long enough, I could make anything right or wrong. So either I'm god, or thruth is relative. Either way: Booyah."; Character = "Jeff Winger"}
            {Quote = "I'm no sociopath. I always know that what I'm doing is wrong. I'm just a guy who doesn't like taking tests, doing work, and getting yelled at. So if you think about it, I'm the sanest person here."; Character = "Jeff Winger"}
            {Quote = "I'm no politician I'm just a fella, I think that beer should be cold, and boots should be dusty. I think 9-11 was bad. And freedom? well, I think that's just a little bit better."; Character = "Jeff Winger"}
            {Quote = "The funny thing about being smart, is that you can get through most of life without ever having to do any work."; Character = "Jeff Winger"}
            {Quote = "Hey, did you hear about the turtle in China? Two packs a day!"; Character = "Jeff Winger"}
            {Quote = "I don't step u to being a leader. I reluctantly accept it when it's thrust upon me."; Character = "Jeff Winger"}
            {Quote = "Don't talk to me about romance. I had a three way in a hot air balloon."; Character = "Jeff Winger"}
            {Quote = "I settled on a thruth today that is always going to be true: that I'll do anything for my friends."; Character = "Jeff Winger"}
            {Quote = "These people don't want me to say what I'll do, they want me to do what I'll say!"; Character = "Jeff Winger"}
            {Quote = "I'm prepared for any insane adventure life throws our way and I don't know about you, but I'm looking forward to every one of them."; Character = "Jeff Winger"}
            {Quote = "Why are we in such a rush to leave the tide pool when the only things waiting for us on shore are the sands of time and the hungry seagulls of slowly growing apart?"; Character = "Jeff Winger"}
            {Quote = "Well, it's been real, but I have a date to catch. Or should I say.. A catch to date."; Character = "Jeff Winger"}
            {Quote = "Oh, like you're famous for your wit."; Character = "Jeff Winger"}
            {Quote = "Some flies are too awesome for the wall."; Character = "Abed Nadir"}
            {Quote = "Cool. Cool cool cool."; Character = "Abed Nadir"}
            {Quote = "You can do whatevey you want, you just have to know what that is."; Character = "Abed Nadir"}
            {Quote = "Sometimes the hardest prisons to break out of, are the ones without locks."; Character = "Abed Nadir"}
            {Quote = "I see your value now."; Character = "Abed Nadir"}
            {Quote = "We'll definitely be back next year. If not, it'll be because an asteroid has destroyed all human civilization. And that's canon."; Character = "Abed Nadir"}
            {Quote = "Our first assignment is a documentary. The're like real movies, but with ugly people."; Character = "Abed Nadir"}
            {Quote = "9/11 was pretty much the 9/11 of the falafel market."; Character = "Abed Nadir"}
            {Quote = "When you really know who you are and what you like about yourself, changing for other people isn't such a big deal."; Character = "Abed Nadir"}
            {Quote = "I looked inside Nicolas Cage and I found a secret: People are random and pointless."; Character = "Abed Nadir"}
            {Quote = "I like football.. but also.. I don't?"; Character = "Abed Nadir"}
            {Quote = "I got self-esteem flowing out of my butt."; Character = "Abed Nadir"}
            {Quote = "Six seasons and a movie!"; Character = "Abed Nadir"}
            {Quote = "I need help reacting to something."; Character = "Abed Nadir"}
            {Quote = "You made me so happy I peed a little."; Character = "Abed Nadir"}
            {Quote = "When the world gets bad enough, the good go crazy. But the smart.. they go bad."; Character = "Abed Nadir"}
            {Quote = "Jeff wants me to make an attack ad. So why is he a pedophile?"; Character = "Abed Nadir"}
            {Quote = "Movie reference"; Character = "Abed Nadir"}
            {Quote = "Did you know you can make napalm out of common dish soap and cat food?"; Character = "Abed Nadir"}
            {Quote = "I painted a tunnel on the side of the library. When it dries, I'm going for it."; Character = "Abed Nadir"}
            {Quote = "This is definitely the darkest timeline."; Character = "Abed Nadir"}
            {Quote = "It's Wednesday, sometimes I eat in Jeff's car. Don't tell him."; Character = "Abed Nadir"}
            {Quote = "Oh my god! I'm finally popular enough to be in the yearbook!"; Character = "Annie Edison"}
            {Quote = "Everybody loves pelicans, they bring babies!"; Character = "Annie Edison"}
            {Quote = "I'm the smartest one in the group and all I've been used for is bait and distraction."; Character = "Annie Edison"}
            {Quote = "I was so unpopular in high school, the crossing guards used to lure me into traffic."; Character = "Annie Edison"}
            {Quote = "Vaugh wants to show me a cloud that looks like a pumpkin!"; Character = "Annie Edison"}
            {Quote = "Freeze mamma-jamma!"; Character = "Annie Edison"}
            {Quote = "They deploy things in football, right? I went for rhyme over clarity."; Character = "Annie Edison"}
            {Quote = "It's like prom. There's a contest and if you win you get to wear a sash and a crown and I'm so jealous Britta I wanna murder you. Aren't you excited?"; Character = "Annie Edison"}
            {Quote = "Guys? Shirley's costume is once again unintentionally ambiguous. I don't know who she's supposed to be, but she's definitely not Miss Piggy. Repeat: not Miss Piggy. You're on your own"; Character = "Annie Edison"}
            {Quote = "Your last blow-off class taught me to live in the moment which I will always regret and never do again."; Character = "Annie Edison"}
            {Quote = "Rich just taught me how to make a flared lip and check for breast lumps!"; Character = "Annie Edison"}
            {Quote = "The name's Annie Edison, but people call me Psycho, 'cause I had a nervous breakdown in high school. My partner's a christian housewife. How can we help you?"; Character = "Annie Edison"}
            {Quote = "A passing grade? Like a C? Why don't I just get pregnant at a bus station?"; Character = "Annie Edison"}
            {Quote = "Do you understand what a conspiracy is? When you conspire with everyone you come across, you're not really conspiring with anyone. You're just doing random crap."; Character = "Annie Edison"}
            {Quote = "Whatevs, we'll take it next semes. Ter. Semester."; Character = "Annie Edison"}
            {Quote = "That was a game. This is paintball."; Character = "Annie Edison"}
            {Quote = "Webster's Dictionary defines? That's the Jim Belushi of speech openings. It accomplishes nothing, but everyone keeps using it and nobody knows why."; Character = "Annie Edison"}
            {Quote = "Who the hell are you always texting? Everyone you know is here!"; Character = "Annie Edison"}
            {Quote = "It's not a pen, it's a principle!"; Character = "Annie Edison"}
            {Quote = "Put it in a letter, Jane Austen!"; Character = "Annie Edison"}
            {Quote = "He was horny, so he dropped him. Man is evil!"; Character = "Annie Edison"}
            {Quote = "Accidents don't just happen over and over and over again, okay? This isn't budget daycare"; Character = "Annie Edison"}
            {Quote = "Umm.. Bitter much?"; Character = "Annie Edison"}
            {Quote = "Don't eat the crab dip, YA YA!"; Character = "Troy Barnes"}
            {Quote = "Never change, or do. I'm not your boss."; Character = "Troy Barnes"}
            {Quote = "I'm going to eat spaceman paninis with black Hitler and there's nothing you can do about it!"; Character = "Troy Barnes"}
            {Quote = "Announcement number two: Butt soup!"; Character = "Troy Barnes"}
            {Quote = "I know you hate it when people do this in movies."; Character = "Troy Barnes"}
            {Quote = "It was awesome, but also.. it wasn't?"; Character = "Troy Barnes"}
            {Quote = "Kettle corn?! That's a fun time snack!"; Character = "Troy Barnes"}
            {Quote = "Girls are supposed to dance. That's why god gave them parts that jiggle."; Character = "Troy Barnes"}
            {Quote = "I don't get history. If I wanted to know what happened in Europe a long time ago, I'd watch Game of Thrones."; Character = "Troy Barnes"}
            {Quote = "I give this year a 'D', for delightful!"; Character = "Troy Barnes"}
            {Quote = "There is a time and place for subtlety, and that time was before Scary Movie."; Character = "Troy Barnes"}
            {Quote = "I wanna see if wiener dogs are born that way, or if they start off normal and then get wiener"; Character = "Troy Barnes"}
            {Quote = "Sometimes I think I lost something really important to me, and then it turns out I already ate it"; Character = "Troy Barnes"}
            {Quote = "If it was cool to eat god, he'd be a chicken finger."; Character = "Troy Barnes"}
            {Quote = "Hey girl, how you livin'?"; Character = "Troy Barnes"}
            {Quote = "Do you get paid more if they do stuff to your butt?"; Character = "Troy Barnes"}
            {Quote = "How 'bout I pound you like a boy?! That didn't come out right."; Character = "Troy Barnes"}
            {Quote = "I'm doctor doogie Seacrest. I think I'm better than everyone else, because I'm forty."; Character = "Troy Barnes"}
            {Quote = "If we get bit we could turn into a zombie. The banana said so."; Character = "Troy Barnes"}
            {Quote = "First time I was punched in the face, I was like 'Oh no!', but then I was like 'this is a story..'"; Character = "Troy Barnes"}
            {Quote = "Do they find thoughts in our butts?"; Character = "Troy Barnes"}
            {Quote = "That thing some call failure, I call living. Breakfast. And I'm not leaving until I've cleaned out the buffet."; Character = "Pierce Hawthorne"}
            {Quote = "That thing some call failure, I call living. Breakfast. And I'm not leaving until I've cleaned out the buffet."; Character = "Pierce Hawthorne"}
        |]

    //[<HttpGet>]
    //member _.Get() =
    //let rng = System.Random()
    //[|
        
    //|]






