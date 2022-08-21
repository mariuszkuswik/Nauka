
double posiadaneJanek=0, dlugJanek=80, zarobekJanek=50;
double posiadaneKarol=0, dlugKarol=80, zarobekKarol=40;

int liczbaDni=0;

do
{
    Console.WriteLine("Janek posiada {0}", posiadaneJanek);
    Console.WriteLine("Karol posiada {0}", posiadaneKarol);

    posiadaneJanek+=zarobekJanek*0.2;
    posiadaneKarol+=zarobekKarol*0.2;

    liczbaDni++; 
    .
}
while(posiadaneJanek<=dlugJanek || posiadaneKarol<=dlugKarol);

Console.WriteLine(liczbaDni);