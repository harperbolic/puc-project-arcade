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

