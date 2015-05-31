# Apricot
[![Build status](https://ci.appveyor.com/api/projects/status/usb0wn7ahy97fqhu?svg=true)](https://ci.appveyor.com/project/cyrilschumacher/apricot)

Application Windows Phone pour le projet **Développement Embarqué** dans le cadre de la 4ème année à l'[exia.cesi](http://www.exia-nancy.com/) de Nancy.

## Objectifs
Les objectifs de cette application sont d'**afficher les plantes actives** (et inactives), les **mesures en temps réel** et selon 
une période exprimées en heures et les **informations sur les variétés**.

## Architecture
Le projet se repose sur une architecture MVVM qui est découpé en plusieurs sous-projets :

- **Apricot.Share**, projet de type *Portable Library*, contient les modèles de vue ainsi que leurs modèles respectives.
- **Apricot.WebServices**, projet de type *Portable Library*, contient les services web.
- **Apricot.Windows** et **Apricot.WindowsPhone**, projet de type *application Windows Phone* et *application Windows 8* contiennent les vues.

## Bibliothèques
Plusieurs bibliothèques ont été utilisées pour le développement de cette application :

### MVVM Light
L'utilisation de cette bibliothèque a permis de construire une application qui se repose sur une architecture MVVM.

### WinRT XAML Toolkit
Les composants de la bibliothèque ont donné la possibilité d'afficher les mesures retournées par le service web sous forme graphique.

### Json.NET
Les bibliothèques de Windows Runtime fournissent des classes permettant la sérialisation et la déserialisation de données JSON. La bibliothèque apporte, en plus de la fonctionnalité de base, des convertisseurs. Elle sera utilisée pour l'échange de données JSON entre l'application mobile et les services web.

## FAQ
### Pourquoi Apricot ?
Le nom de *Apricot* n'a pas été choisi par hasard. Il s'agit d'un acronyme de : 
> A plant who wants to be a connected object

## Copyright

> The MIT License (MIT)
> 
> Copyright (c) 2015 Cyril Schumacher.fr
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy
> of this software and associated documentation files (the "Software"), to deal
> in the Software without restriction, including without limitation the rights
> to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
> copies of the Software, and to permit persons to whom the Software is
> furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all
> copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
> IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
> FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
> AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
> LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
> OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
> SOFTWARE.