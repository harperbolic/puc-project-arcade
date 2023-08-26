# PUC Arcade I

Repositório para criação do Jogo Arcade I da PUC Minas

## Tecnologias

- Unity 2023.1.x
- Blender
- Git
- Github

## Documentações

- Confluence
- Jira (tasks)

## Estrutura de pastas

O projeto segue uma organização detalhada: as pastas `blender` e `fbx` separam ativos originais e exportados por categorias. Em `unity/Assets`, `Models`, `Materials` e `Textures` dividem ativos, enquanto `Scripts` segmenta por `Player`, `AI`, `UI`, `Enemies`, `Environment` e `Other`, simplificando a gestão.

```matemathica
Root
├── blender
│   ├── blend
│   │   ├── Characters    # Arquivos originais de personagens do Blender
│   │   ├── Environment   # Arquivos originais de ambiente do Blender
│   │   ├── Props         # Arquivos originais de objetos do Blender
│   │   └── ...
│   ├── fbx
│   │   ├── Characters    # Arquivos FBX exportados de personagens
│   │   ├── Environment   # Arquivos FBX exportados de ambiente
│   │   ├── Props         # Arquivos FBX exportados de objetos
│   │   └── ...
│
├── unity
│   ├── ...
│   ├── Assets
│   │   ├── Models
│   │   │   ├── Characters    # Modelos 3D de personagens
│   │   │   ├── Environment   # Modelos 3D de ambiente
│   │   │   ├── Props         # Modelos 3D de objetos
│   │   │   └── ...
│   │   ├── Materials
│   │   │   ├── Characters    # Materiais para personagens
│   │   │   ├── Environment   # Materiais para ambiente
│   │   │   ├── Props         # Materiais para objetos
│   │   │   └── ...
│   │   ├── Textures
│   │   │   ├── Characters    # Texturas para personagens
│   │   │   ├── Environment   # Texturas para ambiente
│   │   │   ├── Props         # Texturas para objetos
│   │   │   └── ...
│   │   ├── Scripts
│   │   │   ├── Player        # Scripts relacionados ao jogador
│   │   │   ├── AI            # Scripts de IA
│   │   │   ├── UI            # Scripts de interface
│   │   │   ├── Enemies       # Scripts para inimigos
│   │   │   ├── Environment   # Scripts para ambiente
│   │   │   ├── Other         # Outros scripts
│   │   │   └── ...
│   │   ├── Externals         # Bibliotecas externas
│   │   │   └── ...
│   │   └── ...

```

## Fluxo de Desenvolvimento com GitHub e Pull Requests (PRs)

O GitHub é uma plataforma que ajuda equipes a colaborar no desenvolvimento de projetos de software. Para isto, siga os seguintes passos:

### Clone o Repositório
Primeiro, faça uma cópia do projeto do GitHub para o seu computador.

```sh
git clone git@github.com:rafaeldsb/puc-project-arcade.git
```

### Crie uma Branch
Crie uma nova versão do projeto onde você fará suas mudanças. Dê um nome para a branch que descreva o que você está trabalhando. Use este comando:

```sh
git checkout -b nome-da-sua-branch
# exemplo:
git checkout -b feature/camera-follow-ARC-15
```

**Lembre-se**: Sempre ao iniciar uma nova funcionalidade, criar uma branch nova.

### Faça Mudanças
Agora, você pode editar o código, adicionar arquivos ou fazer qualquer alteração necessária no projeto.

### Commits
Registre suas alterações em pequenos "pacotes" chamados commits. Isso ajuda a manter um histórico claro das mudanças. Use os comandos:

```sh
git add .
git commit -m "Descrição curta das suas mudanças"
# exemplo:
git commit -m "feat: adicionado cinemachine seguindo a nave"
```

### Push (Enviar)
Envie suas mudanças para o GitHub para que outras pessoas possam vê-las. Use o comando:

```sh
# na primeira vez daquela branch:
git push -u origin nome-da-sua-branch
# na segunda vez em diante:
git push
# exemplo:
git push -u origin feature/camera-follow-ARC-15
```

### Pull Request (PR)
Agora vem a parte importante. Abra um Pull Request para que suas alterações sejam revisadas e incorporadas ao projeto principal. No GitHub, clique no botão "New Pull Request" e selecione sua branch

### Revisão e Discussão
As pessoas do grupo podem comentar, fazer perguntas e sugerir alterações nas suas mudanças. Isso ajuda a melhorar a qualidade do código.

### Atualize sua Branch
Se necessário, faça mais mudanças na sua branch com base no feedback recebido.

### Realize o Merge
Após a aprovação de algum colega, você pode "mergear" suas mudanças na branch principal. Isso é feito clicando no botão "Merge Pull Request".
