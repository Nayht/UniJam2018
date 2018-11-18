# UniJam2018

## TODO

### Code

 - [x] Déplacements basiques
 - [x] Boîtes de dialogue basiques
 - [ ] Historique de dialogue
 - [ ] Options de dialogue
 - [x] Dialogue par personnage et par âge
 - [x] Différents personnages à différents âges
 - [x] Mécanique de switch
 - [x] Mécanique de vieillissement

## Comment faire les scripts d'histoire

### Setup

#### Ink

 - Chaque script doit être en extension `.ink` et vous devez avoir [l'extension ink pour Unity](https://assetstore.unity.com/packages/tools/integration/ink-unity-integration-60055)
 - Les fichiers doivent avoir été compilés par ink pour pouvoir être lus (Il doit y avoir des fichiers `.json` de même nom que les `.ink`)

#### Scène

 - La scène ___doit___ comporter un Canvas avec une `Scroll View` et un `Panel`. Dans les deux cas le `Content` doit être assigné à un `Text`.
 - Dans le cas de la `Scroll View` elle ___doit___ être nommée `History` et le `Text` nommé `History Text`.
 	- De plus, son élément `Content` doit posséder un `Content Size Fitter` et un `Vertical Layout Group`. Le premier doit avoir `Vertical Fit : Preferred Size` et le second `Child Controls Size : Height`
 	- Le `Panel` de la boîte de dialogue ___doit___ posséder le script `GuiManager`
 - L'historique doit rester visible pour le moment, il n'est pas cachable
 - La boîte de dialogue est cachée en désactivant les élements `Image` et `Text`

#### Personnages

 - Les personnages d'histoire doivent avoir un script `DialogueEngine` d'attachés et le booléen `has_story` à vrai
 - Leur nom est transmit par le script `Character` ainsi que leur âge et l'âge qu'ils attendent
 - Le chemin des scripts doit être passé aux différents PNJ avec dialogues via leur `DialogueEngine` _depuis_ le dossier Resources et sans l'extension
 - Dans l'idéal, placés sous le dossier Resources/Dialogues mais juste dans Resources devrait suffir

### Structure des scripts et langage ink

 - À l'heure actuelle les PNJs ont une série de dialogue principale, une série gne de dialogue correspondant à l'âge recherché et une série (Éventuellement) qui est lue en boucle après les autres
 - Une série est marquée par une succession de deux ou plus symbôles égal. Les noms des séries précédentes ___doivent___ être `=== GoodAge` et `=== OneLiner` pour la ligne de l'âge et de fin respectivement
 - Une ligne correspond à un paragraphe, soit une boîte de dialogue dans le jeu
 - Une série ___doit___ être terminée de la façon décrite ci-dessous:
 ```
 	(Dernier paragraphe de la série) # Ended
 	-> END
 ```
 - La série avec le bon âge suit la même règle mais on ___doit___ rajoute `# GoodAgeEnded`