grammar Composicion;

// Parser rules
textComp: document EOF;

document: command+;

command : name
        | title
        | h1
        | h2
        | h3
        | bold
        | italic
        | underline
        | para
        | ref
        | list
        | table
        ;

name: INIT_COMMAND BEGIN NAME_PARAM SP* content INIT_COMMAND END NAME_PARAM SP*;
title: INIT_COMMAND BEGIN TITLE_PARAM SP* content INIT_COMMAND END TITLE_PARAM SP*;
h1: INIT_COMMAND BEGIN H1_PARAM SP* content INIT_COMMAND END H1_PARAM SP*;
h2: INIT_COMMAND BEGIN H2_PARAM SP* content INIT_COMMAND END H2_PARAM SP*;
h3: INIT_COMMAND BEGIN H3_PARAM SP* content INIT_COMMAND END H3_PARAM SP*;
bold: INIT_COMMAND BEGIN BOLD_PARAM SP* content INIT_COMMAND END BOLD_PARAM SP*;
italic: INIT_COMMAND BEGIN ITALIC_PARAM SP* content INIT_COMMAND END ITALIC_PARAM SP*;
underline: INIT_COMMAND BEGIN UNDERLINE_PARAM SP* content INIT_COMMAND END UNDERLINE_PARAM SP*;
para: INIT_COMMAND BEGIN PARA_PARAM SP* content INIT_COMMAND END PARA_PARAM SP*;
ref: INIT_COMMAND BEGIN REF_PARAM SP* refItem+ INIT_COMMAND END REF_PARAM SP*;
list: INIT_COMMAND BEGIN LIST_PARAM SP* listItem+ INIT_COMMAND END LIST_PARAM SP*;
table: INIT_COMMAND BEGIN TABLE_PARAM SP* tableRow+ INIT_COMMAND END TABLE_PARAM SP*;
     
content : TEXT                          #justText
        | command                       #justCommand
        | (command* TEXT command*)+     #textWithCommand
        ;
        
refItem: ENUM_LIST TEXT DIV URL;
listItem: ENUM_LIST content;
tableRow: tableCell+ INIT_COMMAND SP*;
tableCell: DIV content;

// Lexer rules
// Param structure
NAME_PARAM: LPAR DOC_NAME RPAR;
TITLE_PARAM: LPAR DOC_TITLE RPAR;
H1_PARAM: LPAR H1 RPAR;
H2_PARAM: LPAR H2 RPAR;
H3_PARAM: LPAR H3 RPAR;
BOLD_PARAM: LPAR BOLD RPAR;
ITALIC_PARAM: LPAR ITALIC RPAR;
UNDERLINE_PARAM: LPAR UNDERLINE RPAR;
PARA_PARAM: LPAR PARA RPAR;
REF_PARAM: LPAR BIBLIOGRAPHY RPAR;
LIST_PARAM: LPAR LIST RPAR;
TABLE_PARAM: LPAR TABLE RPAR;

// About commands
INIT_COMMAND: '/';
LPAR: '(';
RPAR: ')';
BEGIN: 'begin';
END: 'end';

// About params
DOC_NAME: 'name';
DOC_TITLE: 'title';
H1: 'h1';
H2: 'h2';
H3: 'h3';
BOLD: 'b';
ITALIC: 'i';
UNDERLINE: 'u';
PARA: 'p';
BIBLIOGRAPHY: 'ref';
LIST: 'list';
TABLE: 'table';

// About text
URL: SP* ('https'|'http') '://' TEXT ('.com'|'.do'|'.pdf'|'.org') ('/' (TEXT '/'?)?)*;
TEXT: SP* WORD (SP WORD)* SP*;
WORD: [A-Za-z0-9'"!?#$%&={}+-.]+;
DIV: '|';
ENUM_LIST: '*';
SP: ' ';
EOL: ('\n' | '\r\n' | '\r') -> skip;
