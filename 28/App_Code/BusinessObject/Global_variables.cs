using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessObject
{
    public class Global_variables
    {
        private string _A1, _A2, _A3, _A4, _A5, _A6, _A7, _A8, _A9, _A10, _A11, _A12, _A13, _A14, _A15, _A16, _A17, _A18, _A19, _A20, _A21, _A22, _A23, _A24, _A25, _A26
        ,_A27, _A28, _A29, _A30, _A31, _A32, _A33, _A34, _A35, _A36, _A37, _A38, _A39, _A40, _A41, _A42, _A43, _A44, _A45, _A46, _A47, _A48, _A49, _A50, _A51, _A52
        ,_A53, _A54, _A55, _A56, _A57, _A58, _A59, _A60, _A61, _A62, _A63, _A64, _A65, _A66, _A67, _A68, _A69, _A70, _A71, _A72, _A73, _A74, _A75, _A76, _A77, _A78
        ,_A79, _A80, _A81, _A82, _A83, _A84, _A85, _A86, _A87, _A88, _A89, _A90, _A91, _A92, _A93, _A94, _A95, _A96, _A97, _A98, _A99, _A100, _A101, _A102, _A103, _A104
        , _A105, _A106, _A107, _A108, _A109, _A110, _A111, _A112, _A113, _A114, _A115, _A116, _A117, _A118, _A119, _A120

        ,_A121,_A122,_A123,_A124, _A125, _A126, _A127, _A128, _A129, _A130, _A131, _A132, _A133, _A134, _A135, _A136, _A137, _A138, _A139, _A140, _A141, _A142, _A143, _A144
        , _A145, _A146, _A147, _A148, _A149, _A150, _A151, _A152, _A153, _A154, _A155, _A156, _A157, _A158, _A159, _A160, _A161, _A162, _A163, _A164, _A165, _A166, _A167, _A168
        , _A169, _A170, _A171, _A172, _A173, _A174, _A175, _A176, _A177, _A178, _A179, _A180, _A181, _A182, _A183, _A184, _A185, _A186, _A187, _A188, _A189, _A190, _A191, _A192
        , _A193, _A194, _A195, _A196, _A197, _A198, _A199, _A200, _A201, _A202, _A203, _A204, _A205, _A206, _A207, _A208, _A209, _A210, _A211, _A212, _A213, _A214, _A215, _A216
        , _A217, _A218, _A219, _A220, _A221, _A222, _A223, _A224, _A225, _A226, _A227, _A228, _A229, _A230, _A231, _A232, _A233, _A234, _A235, _A236, _A237, _A238, _A239, _A240
        , _A241, _A242, _A243, _A244, _A245, _A246, _A247, _A248, _A249, _A250

        , _A251, _A252, _A253, _A254, _A255, _A256, _A257, _A258, _A259, _A260, _A261, _A262, _A263, _A264, _A265, _A266, _A267, _A268, _A269, _A270, _A271, _A272, _A273, _A274
        , _A275, _A276, _A277, _A278, _A279, _A280, _A281, _A282, _A283, _A284, _A285, _A286, _A287, _A288, _A289, _A290, _A291, _A292, _A293, _A294, _A295, _A296, _A297, _A298
        , _A299, _A300

        , _A301, _A302, _A303, _A304, _A305, _A306, _A307, _A308, _A309, _A310, _A311, _A312, _A313, _A314, _A315, _A316, _A317, _A318, _A319, _A320, _A321, _A322, _A323, _A324, _A325, _A326, _A327
        , _A328, _A329, _A330, _A331, _A332, _A333, _A334, _A335, _A336, _A337, _A338, _A339, _A340, _A341, _A342, _A343, _A344, _A345, _A346, _A347, _A348, _A349, _A350 ,
        _B1, _B2, _B3, _B4, _B5, _B6,
        _B7, _B8, _B9, _B10, _B11, _B12, _B13,
        _B14, _B15, _B16, _B17, _B18, _B19,
        _B20, _B21, _B22, _B23, _B24, _B25,
        _B26, _B27, _B28, _B29, _B30, _B31,
        _B32, _B33, _B34, _B35, _B36, _B37,
        _B38, _B39, _B40, _B41, _B42, _B43,
        _B44, _B45, _B46, _B47, _B48, _B49,
        _B50, _B51, _B52, _B53, _B54, _B55,
        _B56, _B57, _B58, _B59, _B60, _B61,
        _B62, _B63, _B64, _B65, _B66, _B67,
        _B68, _B69, _B70, _B71, _B72, _B73,
        _B74, _B75, _B76, _B77, _B78, _B79,
        _B80, _B81, _B82, _B83, _B84, _B85,
        _B86, _B87, _B88, _B89, _B90, _B91,
        _B92, _B93, _B94, _B95, _B96, _B97,
        _B98, _B99, _B100, _B101, _B102, _B103,
        _B104, _B105, _B106, _B107, _B108, _B109,
        _B110, _B111, _B112, _B113, _B114, _B115,
        _B116, _B117, _B118, _B119, _B120, _B121,
        _B122, _B123, _B124, _B125, _B126, _B127,
        _B128, _B129, _B130, _B131, _B132, _B133,
        _B134, _B135, _B136, _B137, _B138, _B139,
        _B140, _B141, _B142, _B143, _B144, _B145,
        _B146, _B147, _B148, _B149, _B150, _B151,
        _B152, _B153, _B154, _B155, _B156, _B157,
        _B158, _B159, _B160, _B161, _B162, _B163,
        _B164, _B165, _B166, _B167, _B168, _B169,
        _B170, _B171, _B172, _B173, _B174, _B175,
        _B176, _B177, _B178, _B179, _B180, _B181,
        _B182, _B183, _B184, _B185, _B186, _B187,
        _B188, _B189, _B190, _B191, _B192, _B193,
        _B194, _B195, _B196, _B197, _B198, _B199,
        _B200, _B201, _B202, _B203, _B204, _B205,
        _B206, _B207, _B208, _B209, _B210,

        _DD1, _DD2, _DD3, _DD4, _DD5, _DD6,
        _DD7, _DD8, _DD9, _DD10, _DD11, _DD12, _DD13,
        _DD14, _DD15, _DD16, _DD17, _DD18, _DD19,
        _DD20, _DD21, _DD22, _DD23, _DD24, _DD25,
        _DD26, _DD27, _DD28, _DD29, _DD30, _DD31,
        _DD32, _DD33, _DD34, _DD35, _DD36, _DD37,
        _DD38, _DD39, _DD40, _DD41, _DD42, _DD43,
        _DD44, _DD45, _DD46, _DD47, _DD48, _DD49,
        _DD50, _DD51, _DD52, _DD53, _DD54, _DD55,
        _DD56, _DD57, _DD58, _DD59, _DD60, _DD61,
        _DD62, _DD63, _DD64, _DD65, _DD66, _DD67,
        _DD68, _DD69, _DD70, _DD71, _DD72, _DD73,
        _DD74, _DD75, _DD76, _DD77, _DD78, _DD79,
        _DD80, _DD81, _DD82, _DD83, _DD84, _DD85,
        _DD86, _DD87, _DD88, _DD89, _DD90, _DD91,
        _DD92, _DD93, _DD94, _DD95, _DD96, _DD97,
        _DD98, _DD99, _DD100, _DD101, _DD102, _DD103,
        _DD104, _DD105, _DD106, _DD107, _DD108, _DD109,
        _DD110, _DD111, _DD112, _DD113, _DD114, _DD115,
        _DD116, _DD117, _DD118, _DD119, _DD120, _DD121,
        _DD122, _DD123, _DD124, _DD125, _DD126, _DD127,
        _DD128, _DD129, _DD130, _DD131, _DD132, _DD133,
        _DD134, _DD135, _DD136, _DD137, _DD138, _DD139,
        _DD140, _DD141, _DD142, _DD143, _DD144, _DD145,
        _DD146, _DD147, _DD148, _DD149, _DD150, _DD151,
        _DD152, _DD153, _DD154, _DD155, _DD156, _DD157,
        _DD158, _DD159, _DD160, _DD161, _DD162, _DD163,
        _DD164, _DD165, _DD166, _DD167, _DD168, _DD169,
        _DD170, _DD171, _DD172, _DD173, _DD174, _DD175,
        _DD176, _DD177, _DD178, _DD179, _DD180, _DD181,
        _DD182, _DD183, _DD184, _DD185, _DD186, _DD187,
        _DD188, _DD189, _DD190, _DD191, _DD192, _DD193,
        _DD194, _DD195, _DD196, _DD197, _DD198, _DD199,
        _DD200, _DD201, _DD202, _DD203, _DD204, _DD205,
        _DD206, _DD207, _DD208, _DD209, _DD210;


        

        public string A1 { get { return _A1; } set { _A1 = value; } }
        public string A2 { get { return _A2; } set { _A2 = value; } }
        public string A3 { get { return _A3; } set { _A3 = value; } }
        public string A4 { get { return _A4; } set { _A4 = value; } }
        public string A5 { get { return _A5; } set { _A5 = value; } }
        public string A6 { get { return _A6; } set { _A6 = value; } }
        public string A7 { get { return _A7; } set { _A7 = value; } }
        public string A8 { get { return _A8; } set { _A8 = value; } }
        public string A9 { get { return _A9; } set { _A9 = value; } }
        public string A10 { get { return _A10; } set { _A10 = value; } }

        public string A11 { get { return _A11; } set { _A11 = value; } }
        public string A12 { get { return _A12; } set { _A12 = value; } }
        public string A13 { get { return _A13; } set { _A13 = value; } }
        public string A14 { get { return _A14; } set { _A14 = value; } }
        public string A15 { get { return _A15; } set { _A15 = value; } }
        public string A16 { get { return _A16; } set { _A16 = value; } }
        public string A17 { get { return _A17; } set { _A17 = value; } }
        public string A18 { get { return _A18; } set { _A18 = value; } }
        public string A19 { get { return _A19; } set { _A19 = value; } }
        public string A20 { get { return _A20; } set { _A20 = value; } }

        public string A21 { get { return _A21; } set { _A21 = value; } }
        public string A22 { get { return _A22; } set { _A22 = value; } }
        public string A23 { get { return _A23; } set { _A23 = value; } }
        public string A24 { get { return _A24; } set { _A24 = value; } }
        public string A25 { get { return _A25; } set { _A25 = value; } }
        public string A26 { get { return _A26; } set { _A26 = value; } }
        public string A27 { get { return _A27; } set { _A27 = value; } }
        public string A28 { get { return _A28; } set { _A28 = value; } }
        public string A29 { get { return _A29; } set { _A29 = value; } }
        public string A30 { get { return _A30; } set { _A30 = value; } }

        public string A31 { get { return _A31; } set { _A31 = value; } }
        public string A32 { get { return _A32; } set { _A32 = value; } }
        public string A33 { get { return _A33; } set { _A33 = value; } }
        public string A34 { get { return _A34; } set { _A34 = value; } }
        public string A35 { get { return _A35; } set { _A35 = value; } }
        public string A36 { get { return _A36; } set { _A36 = value; } }
        public string A37 { get { return _A37; } set { _A37 = value; } }
        public string A38 { get { return _A38; } set { _A38 = value; } }
        public string A39 { get { return _A39; } set { _A39 = value; } }
        public string A40 { get { return _A40; } set { _A40 = value; } }

        public string A41 { get { return _A41; } set { _A41 = value; } }
        public string A42 { get { return _A42; } set { _A42 = value; } }
        public string A43 { get { return _A43; } set { _A43 = value; } }
        public string A44 { get { return _A44; } set { _A44 = value; } }
        public string A45 { get { return _A45; } set { _A45 = value; } }
        public string A46 { get { return _A46; } set { _A46 = value; } }
        public string A47 { get { return _A47; } set { _A47 = value; } }
        public string A48 { get { return _A48; } set { _A48 = value; } }
        public string A49 { get { return _A49; } set { _A49 = value; } }
        public string A50 { get { return _A50; } set { _A50 = value; } }

        public string A51 { get { return _A51; } set { _A51 = value; } }
        public string A52 { get { return _A52; } set { _A52 = value; } }
        public string A53 { get { return _A53; } set { _A53 = value; } }
        public string A54 { get { return _A54; } set { _A54 = value; } }
        public string A55 { get { return _A55; } set { _A55 = value; } }
        public string A56 { get { return _A56; } set { _A56 = value; } }
        public string A57 { get { return _A57; } set { _A57 = value; } }
        public string A58 { get { return _A58; } set { _A58 = value; } }
        public string A59 { get { return _A59; } set { _A59 = value; } }
        public string A60 { get { return _A60; } set { _A60 = value; } }

        public string A61 { get { return _A61; } set { _A61 = value; } }
        public string A62 { get { return _A62; } set { _A62 = value; } }
        public string A63 { get { return _A63; } set { _A63 = value; } }
        public string A64 { get { return _A64; } set { _A64 = value; } }
        public string A66 { get { return _A65; } set { _A65 = value; } }
        public string A67 { get { return _A66; } set { _A66 = value; } }
        public string A68 { get { return _A67; } set { _A67 = value; } }
        public string A69 { get { return _A68; } set { _A68 = value; } }
        public string A70 { get { return _A69; } set { _A69 = value; } }
        public string A65 { get { return _A70; } set { _A70 = value; } }

        public string A71 { get { return _A71; } set { _A71 = value; } }
        public string A72 { get { return _A72; } set { _A72 = value; } }
        public string A73 { get { return _A73; } set { _A73 = value; } }
        public string A74 { get { return _A74; } set { _A74 = value; } }
        public string A75 { get { return _A75; } set { _A75 = value; } }
        public string A76 { get { return _A76; } set { _A76 = value; } }
        public string A77 { get { return _A77; } set { _A77 = value; } }
        public string A78 { get { return _A78; } set { _A78 = value; } }
        public string A79 { get { return _A79; } set { _A79 = value; } }
        public string A80 { get { return _A80; } set { _A80 = value; } }

        public string A81 { get { return _A81; } set { _A81 = value; } }
        public string A82 { get { return _A82; } set { _A82 = value; } }
        public string A83 { get { return _A83; } set { _A83 = value; } }
        public string A84 { get { return _A84; } set { _A84 = value; } }
        public string A85 { get { return _A85; } set { _A85 = value; } }
        public string A86 { get { return _A86; } set { _A86 = value; } }
        public string A87 { get { return _A87; } set { _A87 = value; } }
        public string A88 { get { return _A88; } set { _A88 = value; } }
        public string A89 { get { return _A89; } set { _A89 = value; } }
        public string A90 { get { return _A90; } set { _A90 = value; } }

        public string A91 { get { return _A91; } set { _A91 = value; } }
        public string A92 { get { return _A92; } set { _A92 = value; } }
        public string A93 { get { return _A93; } set { _A93 = value; } }
        public string A94 { get { return _A94; } set { _A94 = value; } }
        public string A95 { get { return _A95; } set { _A95 = value; } }
        public string A96 { get { return _A96; } set { _A96 = value; } }
        public string A97 { get { return _A97; } set { _A97 = value; } }
        public string A98 { get { return _A98; } set { _A98 = value; } }
        public string A99 { get { return _A99; } set { _A99 = value; } }
        public string A100 { get { return _A100; } set { _A100 = value; } }

        public string A101 { get { return _A101; } set { _A101 = value; } }
        public string A102 { get { return _A102; } set { _A102 = value; } }
        public string A103 { get { return _A103; } set { _A103 = value; } }
        public string A104 { get { return _A104; } set { _A104 = value; } }

        public string A105 { get { return _A105; } set { _A105 = value; } }
        public string A106 { get { return _A106; } set { _A106 = value; } }
        public string A107 { get { return _A107; } set { _A107 = value; } }
        public string A108 { get { return _A108; } set { _A108 = value; } }
        public string A109 { get { return _A109; } set { _A109 = value; } }
        public string A110 { get { return _A110; } set { _A110 = value; } }
        public string A111 { get { return _A111; } set { _A111 = value; } }
        public string A112 { get { return _A112; } set { _A112 = value; } }
        public string A113 { get { return _A113; } set { _A113 = value; } }
        public string A114 { get { return _A114; } set { _A114 = value; } }

        public string A115 { get { return _A115; } set { _A115 = value; } }
        public string A116 { get { return _A116; } set { _A116 = value; } }
        public string A117 { get { return _A117; } set { _A117 = value; } }
        public string A118 { get { return _A118; } set { _A118 = value; } }
        public string A119 { get { return _A119; } set { _A119 = value; } }
        public string A120 { get { return _A120; } set { _A120 = value; } }

        public string A121 { get { return _A121; } set { _A121 = value; } }
        public string A122 { get { return _A122; } set { _A122 = value; } }
        public string A123 { get { return _A123; } set { _A123 = value; } }
        public string A124 { get { return _A124; } set { _A124 = value; } }
        public string A125 { get { return _A125; } set { _A125 = value; } }
        public string A126 { get { return _A126; } set { _A126 = value; } }
        public string A127 { get { return _A127; } set { _A127 = value; } }
        public string A128 { get { return _A128; } set { _A128 = value; } }
        public string A129 { get { return _A129; } set { _A129 = value; } }
        public string A130 { get { return _A130; } set { _A130 = value; } }
        public string A131 { get { return _A131; } set { _A131 = value; } }
        public string A132 { get { return _A132; } set { _A132 = value; } }
        public string A133 { get { return _A133; } set { _A133 = value; } }
        public string A134 { get { return _A134; } set { _A134 = value; } }
        public string A135 { get { return _A135; } set { _A135 = value; } }
        public string A136 { get { return _A136; } set { _A136 = value; } }
        public string A137 { get { return _A137; } set { _A137 = value; } }
        public string A138 { get { return _A138; } set { _A138 = value; } }
        public string A139 { get { return _A139; } set { _A139 = value; } }
        public string A140 { get { return _A140; } set { _A140 = value; } }
        public string A141 { get { return _A141; } set { _A141 = value; } }
        public string A142 { get { return _A142; } set { _A142 = value; } }
        public string A143 { get { return _A143; } set { _A143 = value; } }
        public string A144 { get { return _A144; } set { _A144 = value; } }
        public string A145 { get { return _A145; } set { _A145 = value; } }
        public string A146 { get { return _A146; } set { _A146 = value; } }
        public string A147 { get { return _A147; } set { _A147 = value; } }
        public string A148 { get { return _A148; } set { _A148 = value; } }
        public string A149 { get { return _A149; } set { _A149 = value; } }
        public string A150 { get { return _A150; } set { _A150 = value; } }

        public string A151 { get { return _A151; } set { _A151 = value; } }
        public string A152 { get { return _A152; } set { _A152 = value; } }
        public string A153 { get { return _A153; } set { _A153 = value; } }
        public string A154 { get { return _A154; } set { _A154 = value; } }
        public string A155 { get { return _A155; } set { _A155 = value; } }
        public string A156 { get { return _A156; } set { _A156 = value; } }
        public string A157 { get { return _A157; } set { _A157 = value; } }
        public string A158 { get { return _A158; } set { _A158 = value; } }
        public string A159 { get { return _A159; } set { _A159 = value; } }
        public string A160 { get { return _A160; } set { _A160 = value; } }
        public string A161 { get { return _A161; } set { _A161 = value; } }
        public string A162 { get { return _A162; } set { _A162 = value; } }
        public string A163 { get { return _A163; } set { _A163 = value; } }
        public string A164 { get { return _A164; } set { _A164 = value; } }
        public string A165 { get { return _A165; } set { _A165 = value; } }
        public string A166 { get { return _A166; } set { _A166 = value; } }
        public string A167 { get { return _A167; } set { _A167 = value; } }
        public string A168 { get { return _A168; } set { _A168 = value; } }
        public string A169 { get { return _A169; } set { _A169 = value; } }
        public string A170 { get { return _A170; } set { _A170 = value; } }
        public string A171 { get { return _A171; } set { _A171 = value; } }
        public string A172 { get { return _A172; } set { _A172 = value; } }
        public string A173 { get { return _A173; } set { _A173 = value; } }
        public string A174 { get { return _A174; } set { _A174 = value; } }
        public string A175 { get { return _A175; } set { _A175 = value; } }
        public string A176 { get { return _A176; } set { _A176 = value; } }
        public string A177 { get { return _A177; } set { _A177 = value; } }
        public string A178 { get { return _A178; } set { _A178 = value; } }
        public string A179 { get { return _A179; } set { _A179 = value; } }

        public string A180 { get { return _A180; } set { _A180 = value; } }
        public string A181 { get { return _A181; } set { _A181 = value; } }
        public string A182 { get { return _A182; } set { _A182 = value; } }
        public string A183 { get { return _A183; } set { _A183 = value; } }
        public string A184 { get { return _A184; } set { _A184 = value; } }
        public string A185 { get { return _A185; } set { _A185 = value; } }
        public string A186 { get { return _A186; } set { _A186 = value; } }
        public string A187 { get { return _A187; } set { _A187 = value; } }
        public string A188 { get { return _A188; } set { _A188 = value; } }
        public string A189 { get { return _A189; } set { _A189 = value; } }
        public string A190 { get { return _A190; } set { _A190 = value; } }
        public string A191 { get { return _A191; } set { _A191 = value; } }
        public string A192 { get { return _A192; } set { _A192 = value; } }
        public string A193 { get { return _A193; } set { _A193 = value; } }
        public string A194 { get { return _A194; } set { _A194 = value; } }
        public string A195 { get { return _A195; } set { _A195 = value; } }
        public string A196 { get { return _A196; } set { _A196 = value; } }
        public string A197 { get { return _A197; } set { _A197 = value; } }
        public string A198 { get { return _A198; } set { _A198 = value; } }
        public string A199 { get { return _A199; } set { _A199 = value; } }
        public string A200 { get { return _A200; } set { _A200 = value; } }

        public string A201 { get { return _A201; } set { _A201 = value; } }
        public string A202 { get { return _A202; } set { _A202 = value; } }
        public string A203 { get { return _A203; } set { _A203 = value; } }
        public string A204 { get { return _A204; } set { _A204 = value; } }
        public string A205 { get { return _A205; } set { _A205 = value; } }
        public string A206 { get { return _A206; } set { _A206 = value; } }
        public string A207 { get { return _A207; } set { _A207 = value; } }
        public string A208 { get { return _A208; } set { _A208 = value; } }
        public string A209 { get { return _A209; } set { _A209 = value; } }
        public string A210 { get { return _A210; } set { _A210 = value; } }
        public string A211 { get { return _A211; } set { _A211 = value; } }
        public string A212 { get { return _A212; } set { _A212 = value; } }
        public string A213 { get { return _A213; } set { _A213 = value; } }
        public string A214 { get { return _A214; } set { _A214 = value; } }
        public string A215 { get { return _A215; } set { _A215 = value; } }
        public string A216 { get { return _A216; } set { _A216 = value; } }


        public string A217 { get { return _A217; } set { _A217 = value; } }
        public string A218 { get { return _A218; } set { _A218 = value; } }
        public string A219 { get { return _A219; } set { _A219 = value; } }
        public string A220 { get { return _A220; } set { _A220 = value; } }
        public string A221 { get { return _A221; } set { _A221 = value; } }
        public string A222 { get { return _A222; } set { _A222 = value; } }
        public string A223 { get { return _A223; } set { _A223 = value; } }
        public string A224 { get { return _A224; } set { _A224 = value; } }
        public string A225 { get { return _A225; } set { _A225 = value; } }
        public string A226 { get { return _A226; } set { _A226 = value; } }
        public string A227 { get { return _A227; } set { _A227 = value; } }
        public string A228 { get { return _A228; } set { _A228 = value; } }
        public string A229 { get { return _A229; } set { _A229 = value; } }
        public string A230 { get { return _A230; } set { _A230 = value; } }
        public string A231 { get { return _A231; } set { _A231 = value; } }
        public string A232 { get { return _A232; } set { _A232 = value; } }
        public string A233 { get { return _A233; } set { _A233 = value; } }
        public string A234 { get { return _A234; } set { _A234 = value; } }
        public string A235 { get { return _A235; } set { _A235 = value; } }
        public string A236 { get { return _A236; } set { _A236 = value; } }
        public string A237 { get { return _A237; } set { _A237 = value; } }
        public string A238 { get { return _A238; } set { _A238 = value; } }
        public string A239 { get { return _A239; } set { _A239 = value; } }
        public string A240 { get { return _A240; } set { _A240 = value; } }
        public string A241 { get { return _A241; } set { _A241 = value; } }
        public string A242 { get { return _A242; } set { _A242 = value; } }
        public string A243 { get { return _A243; } set { _A243 = value; } }
        public string A244 { get { return _A244; } set { _A244 = value; } }
        public string A245 { get { return _A245; } set { _A245 = value; } }
        public string A246 { get { return _A246; } set { _A246 = value; } }
        public string A247 { get { return _A247; } set { _A247 = value; } }
        public string A248 { get { return _A248; } set { _A248 = value; } }
        public string A249 { get { return _A249; } set { _A249 = value; } }
        public string A250 { get { return _A250; } set { _A250 = value; } }

        public string A251 { get { return _A251; } set { _A251 = value; } }
        public string A252 { get { return _A252; } set { _A252 = value; } }
        public string A253 { get { return _A253; } set { _A253 = value; } }
        public string A254 { get { return _A254; } set { _A254 = value; } }
        public string A255 { get { return _A255; } set { _A255 = value; } }
        public string A256 { get { return _A256; } set { _A256 = value; } }
        public string A257 { get { return _A257; } set { _A257 = value; } }
        public string A258 { get { return _A258; } set { _A258 = value; } }
        public string A259 { get { return _A259; } set { _A259 = value; } }
        public string A260 { get { return _A260; } set { _A260 = value; } }
        public string A261 { get { return _A261; } set { _A261 = value; } }
        public string A262 { get { return _A262; } set { _A262 = value; } }
        public string A263 { get { return _A263; } set { _A263 = value; } }
        public string A264 { get { return _A264; } set { _A264 = value; } }
        public string A265 { get { return _A265; } set { _A265 = value; } }
        public string A266 { get { return _A266; } set { _A266 = value; } }
        public string A267 { get { return _A267; } set { _A267 = value; } }
        public string A268 { get { return _A268; } set { _A268 = value; } }
        public string A269 { get { return _A269; } set { _A269 = value; } }
        public string A270 { get { return _A270; } set { _A270 = value; } }
        public string A271 { get { return _A271; } set { _A271 = value; } }
        public string A272 { get { return _A272; } set { _A272 = value; } }
        public string A273 { get { return _A273; } set { _A273 = value; } }
        public string A274 { get { return _A274; } set { _A274 = value; } }
        public string A275 { get { return _A275; } set { _A275 = value; } }
        public string A276 { get { return _A276; } set { _A276 = value; } }
        public string A277 { get { return _A277; } set { _A277 = value; } }
        public string A278 { get { return _A278; } set { _A278 = value; } }
        public string A279 { get { return _A279; } set { _A279 = value; } }
        public string A280 { get { return _A280; } set { _A280 = value; } }
        public string A281 { get { return _A281; } set { _A281 = value; } }
        public string A282 { get { return _A282; } set { _A282 = value; } }
        public string A283 { get { return _A283; } set { _A283 = value; } }
        public string A284 { get { return _A284; } set { _A284 = value; } }
        public string A285 { get { return _A285; } set { _A285 = value; } }
        public string A286 { get { return _A286; } set { _A286 = value; } }
        public string A287 { get { return _A287; } set { _A287 = value; } }
        public string A288 { get { return _A288; } set { _A288 = value; } }
        public string A289 { get { return _A289; } set { _A289 = value; } }
        public string A290 { get { return _A290; } set { _A290 = value; } }
        public string A291 { get { return _A291; } set { _A291 = value; } }
        public string A292 { get { return _A292; } set { _A292 = value; } }
        public string A293 { get { return _A293; } set { _A293 = value; } }
        public string A294 { get { return _A294; } set { _A294 = value; } }
        public string A295 { get { return _A295; } set { _A295 = value; } }
        public string A296 { get { return _A296; } set { _A296 = value; } }
        public string A297 { get { return _A297; } set { _A297 = value; } }
        public string A298 { get { return _A298; } set { _A298 = value; } }
        public string A299 { get { return _A299; } set { _A299 = value; } }
        public string A300 { get { return _A300; } set { _A300 = value; } }


        public string A301 { get { return _A301; } set { _A301 = value; } }
        public string A302 { get { return _A302; } set { _A302 = value; } }
        public string A303 { get { return _A303; } set { _A303 = value; } }
        public string A304 { get { return _A304; } set { _A304 = value; } }
        public string A305 { get { return _A305; } set { _A305 = value; } }
        public string A306 { get { return _A306; } set { _A306 = value; } }
        public string A307 { get { return _A307; } set { _A307 = value; } }
        public string A308 { get { return _A308; } set { _A308 = value; } }
        public string A309 { get { return _A309; } set { _A309 = value; } }
        public string A310 { get { return _A310; } set { _A310 = value; } }
        public string A311 { get { return _A311; } set { _A311 = value; } }
        public string A312 { get { return _A312; } set { _A312 = value; } }
        public string A313 { get { return _A313; } set { _A313 = value; } }
        public string A314 { get { return _A314; } set { _A314 = value; } }
        public string A315 { get { return _A315; } set { _A315 = value; } }
        public string A316 { get { return _A316; } set { _A316 = value; } }
        public string A317 { get { return _A317; } set { _A317 = value; } }
        public string A318 { get { return _A318; } set { _A318 = value; } }
        public string A319 { get { return _A319; } set { _A319 = value; } }
        public string A320 { get { return _A320; } set { _A320 = value; } }
        public string A321 { get { return _A321; } set { _A321 = value; } }
        public string A322 { get { return _A322; } set { _A322 = value; } }
        public string A323 { get { return _A323; } set { _A323 = value; } }
        public string A324 { get { return _A324; } set { _A324 = value; } }
        public string A325 { get { return _A325; } set { _A325 = value; } }
        public string A326 { get { return _A326; } set { _A326 = value; } }
        public string A327 { get { return _A327; } set { _A327 = value; } }
        public string A328 { get { return _A328; } set { _A328 = value; } }
        public string A329 { get { return _A329; } set { _A329 = value; } }
        public string A330 { get { return _A330; } set { _A330 = value; } }
        public string A331 { get { return _A331; } set { _A331 = value; } }
        public string A332 { get { return _A332; } set { _A332 = value; } }
        public string A333 { get { return _A333; } set { _A333 = value; } }
        public string A334 { get { return _A334; } set { _A334 = value; } }
        public string A335 { get { return _A335; } set { _A335 = value; } }
        public string A336 { get { return _A336; } set { _A336 = value; } }
        public string A337 { get { return _A337; } set { _A337 = value; } }
        public string A338 { get { return _A338; } set { _A338 = value; } }
        public string A339 { get { return _A339; } set { _A339 = value; } }
        public string A340 { get { return _A340; } set { _A340 = value; } }
        public string A341 { get { return _A341; } set { _A341 = value; } }
        public string A342 { get { return _A342; } set { _A342 = value; } }
        public string A343 { get { return _A343; } set { _A343 = value; } }
        public string A344 { get { return _A344; } set { _A344 = value; } }
        public string A345 { get { return _A345; } set { _A345 = value; } }
        public string A346 { get { return _A346; } set { _A346 = value; } }
        public string A347 { get { return _A347; } set { _A347 = value; } }
        public string A348 { get { return _A348; } set { _A348 = value; } }
        public string A349 { get { return _A349; } set { _A349 = value; } }
        public string A350 { get { return _A350; } set { _A350 = value; } }


        public string B1 { get { return _B1; } set { _B1 = value; } }
        public string B2 { get { return _B2; } set { _B2 = value; } }
        public string B3 { get { return _B3; } set { _B3 = value; } }
        public string B4 { get { return _B4; } set { _B4 = value; } }
        public string B5 { get { return _B5; } set { _B5 = value; } }
        public string B6 { get { return _B6; } set { _B6 = value; } }
        public string B7 { get { return _B7; } set { _B7 = value; } }
        public string B8 { get { return _B8; } set { _B8 = value; } }
        public string B9 { get { return _B9; } set { _B9 = value; } }
        public string B10 { get { return _B10; } set { _B10 = value; } }
        public string B11 { get { return _B11; } set { _B11 = value; } }
        public string B12 { get { return _B12; } set { _B12 = value; } }
        public string B13 { get { return _B13; } set { _B13 = value; } }
        public string B14 { get { return _B14; } set { _B14 = value; } }
        public string B15 { get { return _B15; } set { _B15 = value; } }
        public string B16 { get { return _B16; } set { _B16 = value; } }
        public string B17 { get { return _B17; } set { _B17 = value; } }
        public string B18 { get { return _B18; } set { _B18 = value; } }
        public string B19 { get { return _B19; } set { _B19 = value; } }
        public string B20 { get { return _B20; } set { _B20 = value; } }
        public string B21 { get { return _B21; } set { _B21 = value; } }
        public string B22 { get { return _B22; } set { _B22 = value; } }
        public string B23 { get { return _B23; } set { _B23 = value; } }
        public string B24 { get { return _B24; } set { _B24 = value; } }
        public string B25 { get { return _B25; } set { _B25 = value; } }
        public string B26 { get { return _B26; } set { _B26 = value; } }
        public string B27 { get { return _B27; } set { _B27 = value; } }
        public string B28 { get { return _B28; } set { _B28 = value; } }
        public string B29 { get { return _B29; } set { _B29 = value; } }
        public string B30 { get { return _B30; } set { _B30 = value; } }
        public string B31 { get { return _B31; } set { _B31 = value; } }
        public string B32 { get { return _B32; } set { _B32 = value; } }
        public string B33 { get { return _B33; } set { _B33 = value; } }
        public string B34 { get { return _B34; } set { _B34 = value; } }
        public string B35 { get { return _B35; } set { _B35 = value; } }
        public string B36 { get { return _B36; } set { _B36 = value; } }
        public string B37 { get { return _B37; } set { _B37 = value; } }
        public string B38 { get { return _B38; } set { _B38 = value; } }
        public string B39 { get { return _B39; } set { _B39 = value; } }
        public string B40 { get { return _B40; } set { _B40 = value; } }
        public string B41 { get { return _B41; } set { _B41 = value; } }
        public string B42 { get { return _B42; } set { _B42 = value; } }
        public string B43 { get { return _B43; } set { _B43 = value; } }
        public string B44 { get { return _B44; } set { _B44 = value; } }
        public string B45 { get { return _B45; } set { _B45 = value; } }
        public string B46 { get { return _B46; } set { _B46 = value; } }
        public string B47 { get { return _B47; } set { _B47 = value; } }
        public string B48 { get { return _B48; } set { _B48 = value; } }
        public string B49 { get { return _B49; } set { _B49 = value; } }
        public string B50 { get { return _B50; } set { _B50 = value; } }
        public string B51 { get { return _B51; } set { _B51 = value; } }
        public string B52 { get { return _B52; } set { _B52 = value; } }
        public string B53 { get { return _B53; } set { _B53 = value; } }
        public string B54 { get { return _B54; } set { _B54 = value; } }
        public string B55 { get { return _B55; } set { _B55 = value; } }
        public string B56 { get { return _B56; } set { _B56 = value; } }
        public string B57 { get { return _B57; } set { _B57 = value; } }
        public string B58 { get { return _B58; } set { _B58 = value; } }
        public string B59 { get { return _B59; } set { _B59 = value; } }
        public string B60 { get { return _B60; } set { _B60 = value; } }
        public string B61 { get { return _B61; } set { _B61 = value; } }
        public string B62 { get { return _B62; } set { _B62 = value; } }
        public string B63 { get { return _B63; } set { _B63 = value; } }
        public string B64 { get { return _B64; } set { _B64 = value; } }
        public string B65 { get { return _B65; } set { _B65 = value; } }
        public string B66 { get { return _B66; } set { _B66 = value; } }
        public string B67 { get { return _B67; } set { _B67 = value; } }
        public string B68 { get { return _B68; } set { _B68 = value; } }
        public string B69 { get { return _B69; } set { _B69 = value; } }
        public string B70 { get { return _B70; } set { _B70 = value; } }
        public string B71 { get { return _B71; } set { _B71 = value; } }
        public string B72 { get { return _B72; } set { _B72 = value; } }
        public string B73 { get { return _B73; } set { _B73 = value; } }
        public string B74 { get { return _B74; } set { _B74 = value; } }
        public string B75 { get { return _B75; } set { _B75 = value; } }
        public string B76 { get { return _B76; } set { _B76 = value; } }
        public string B77 { get { return _B77; } set { _B77 = value; } }
        public string B78 { get { return _B78; } set { _B78 = value; } }
        public string B79 { get { return _B79; } set { _B79 = value; } }
        public string B80 { get { return _B80; } set { _B80 = value; } }
        public string B81 { get { return _B81; } set { _B81 = value; } }
        public string B82 { get { return _B82; } set { _B82 = value; } }
        public string B83 { get { return _B83; } set { _B83 = value; } }
        public string B84 { get { return _B84; } set { _B84 = value; } }
        public string B85 { get { return _B85; } set { _B85 = value; } }
        public string B86 { get { return _B86; } set { _B86 = value; } }
        public string B87 { get { return _B87; } set { _B87 = value; } }
        public string B88 { get { return _B88; } set { _B88 = value; } }
        public string B89 { get { return _B89; } set { _B89 = value; } }
        public string B90 { get { return _B90; } set { _B90 = value; } }
        public string B91 { get { return _B91; } set { _B91 = value; } }
        public string B92 { get { return _B92; } set { _B92 = value; } }
        public string B93 { get { return _B93; } set { _B93 = value; } }
        public string B94 { get { return _B94; } set { _B94 = value; } }
        public string B95 { get { return _B95; } set { _B95 = value; } }
        public string B96 { get { return _B96; } set { _B96 = value; } }
        public string B97 { get { return _B97; } set { _B97 = value; } }
        public string B98 { get { return _B98; } set { _B98 = value; } }
        public string B99 { get { return _B99; } set { _B99 = value; } }
        public string B100 { get { return _B100; } set { _B100 = value; } }
        public string B101 { get { return _B101; } set { _B101 = value; } }
        public string B102 { get { return _B102; } set { _B102 = value; } }
        public string B103 { get { return _B103; } set { _B103 = value; } }
        public string B104 { get { return _B104; } set { _B104 = value; } }
        public string B105 { get { return _B105; } set { _B105 = value; } }
        public string B106 { get { return _B106; } set { _B106 = value; } }
        public string B107 { get { return _B107; } set { _B107 = value; } }
        public string B108 { get { return _B108; } set { _B108 = value; } }
        public string B109 { get { return _B109; } set { _B109 = value; } }
        public string B110 { get { return _B110; } set { _B110 = value; } }
        public string B111 { get { return _B111; } set { _B111 = value; } }
        public string B112 { get { return _B112; } set { _B112 = value; } }
        public string B113 { get { return _B113; } set { _B113 = value; } }
        public string B114 { get { return _B114; } set { _B114 = value; } }
        public string B115 { get { return _B115; } set { _B115 = value; } }
        public string B116 { get { return _B116; } set { _B116 = value; } }
        public string B117 { get { return _B117; } set { _B117 = value; } }
        public string B118 { get { return _B118; } set { _B118 = value; } }
        public string B119 { get { return _B119; } set { _B119 = value; } }
        public string B120 { get { return _B120; } set { _B120 = value; } }
        public string B121 { get { return _B121; } set { _B121 = value; } }
        public string B122 { get { return _B122; } set { _B122 = value; } }
        public string B123 { get { return _B123; } set { _B123 = value; } }
        public string B124 { get { return _B124; } set { _B124 = value; } }
        public string B125 { get { return _B125; } set { _B125 = value; } }
        public string B126 { get { return _B126; } set { _B126 = value; } }
        public string B127 { get { return _B127; } set { _B127 = value; } }
        public string B128 { get { return _B128; } set { _B128 = value; } }
        public string B129 { get { return _B129; } set { _B129 = value; } }
        public string B130 { get { return _B130; } set { _B130 = value; } }
        public string B131 { get { return _B131; } set { _B131 = value; } }
        public string B132 { get { return _B132; } set { _B132 = value; } }
        public string B133 { get { return _B133; } set { _B133 = value; } }
        public string B134 { get { return _B134; } set { _B134 = value; } }
        public string B135 { get { return _B135; } set { _B135 = value; } }
        public string B136 { get { return _B136; } set { _B136 = value; } }
        public string B137 { get { return _B137; } set { _B137 = value; } }
        public string B138 { get { return _B138; } set { _B138 = value; } }
        public string B139 { get { return _B139; } set { _B139 = value; } }
        public string B140 { get { return _B140; } set { _B140 = value; } }
        public string B141 { get { return _B141; } set { _B141 = value; } }
        public string B142 { get { return _B142; } set { _B142 = value; } }
        public string B143 { get { return _B143; } set { _B143 = value; } }
        public string B144 { get { return _B144; } set { _B144 = value; } }
        public string B145 { get { return _B145; } set { _B145 = value; } }
        public string B146 { get { return _B146; } set { _B146 = value; } }
        public string B147 { get { return _B147; } set { _B147 = value; } }
        public string B148 { get { return _B148; } set { _B148 = value; } }
        public string B149 { get { return _B149; } set { _B149 = value; } }
        public string B150 { get { return _B150; } set { _B150 = value; } }
        public string B151 { get { return _B151; } set { _B151 = value; } }
        public string B152 { get { return _B152; } set { _B152 = value; } }
        public string B153 { get { return _B153; } set { _B153 = value; } }
        public string B154 { get { return _B154; } set { _B154 = value; } }
        public string B155 { get { return _B155; } set { _B155 = value; } }
        public string B156 { get { return _B156; } set { _B156 = value; } }
        public string B157 { get { return _B157; } set { _B157 = value; } }
        public string B158 { get { return _B158; } set { _B158 = value; } }
        public string B159 { get { return _B159; } set { _B159 = value; } }
        public string B160 { get { return _B160; } set { _B160 = value; } }
        public string B161 { get { return _B161; } set { _B161 = value; } }
        public string B162 { get { return _B162; } set { _B162 = value; } }
        public string B163 { get { return _B163; } set { _B163 = value; } }
        public string B164 { get { return _B164; } set { _B164 = value; } }
        public string B165 { get { return _B165; } set { _B165 = value; } }
        public string B166 { get { return _B166; } set { _B166 = value; } }
        public string B167 { get { return _B167; } set { _B167 = value; } }
        public string B168 { get { return _B168; } set { _B168 = value; } }
        public string B169 { get { return _B169; } set { _B169 = value; } }
        public string B170 { get { return _B170; } set { _B170 = value; } }
        public string B171 { get { return _B171; } set { _B171 = value; } }
        public string B172 { get { return _B172; } set { _B172 = value; } }
        public string B173 { get { return _B173; } set { _B173 = value; } }
        public string B174 { get { return _B174; } set { _B174 = value; } }
        public string B175 { get { return _B175; } set { _B175 = value; } }
        public string B176 { get { return _B176; } set { _B176 = value; } }
        public string B177 { get { return _B177; } set { _B177 = value; } }
        public string B178 { get { return _B178; } set { _B178 = value; } }
        public string B179 { get { return _B179; } set { _B179 = value; } }
        public string B180 { get { return _B180; } set { _B180 = value; } }
        public string B181 { get { return _B181; } set { _B181 = value; } }
        public string B182 { get { return _B182; } set { _B182 = value; } }
        public string B183 { get { return _B183; } set { _B183 = value; } }
        public string B184 { get { return _B184; } set { _B184 = value; } }
        public string B185 { get { return _B185; } set { _B185 = value; } }
        public string B186 { get { return _B186; } set { _B186 = value; } }
        public string B187 { get { return _B187; } set { _B187 = value; } }
        public string B188 { get { return _B188; } set { _B188 = value; } }
        public string B189 { get { return _B189; } set { _B189 = value; } }
        public string B190 { get { return _B190; } set { _B190 = value; } }
        public string B191 { get { return _B191; } set { _B191 = value; } }
        public string B192 { get { return _B192; } set { _B192 = value; } }
        public string B193 { get { return _B193; } set { _B193 = value; } }
        public string B194 { get { return _B194; } set { _B194 = value; } }
        public string B195 { get { return _B195; } set { _B195 = value; } }
        public string B196 { get { return _B196; } set { _B196 = value; } }
        public string B197 { get { return _B197; } set { _B197 = value; } }
        public string B198 { get { return _B198; } set { _B198 = value; } }
        public string B199 { get { return _B199; } set { _B199 = value; } }
        public string B200 { get { return _B200; } set { _B200 = value; } }
        public string B201 { get { return _B201; } set { _B201 = value; } }
        public string B202 { get { return _B202; } set { _B202 = value; } }
        public string B203 { get { return _B203; } set { _B203 = value; } }
        public string B204 { get { return _B204; } set { _B204 = value; } }
        public string B205 { get { return _B205; } set { _B205 = value; } }
        public string B206 { get { return _B206; } set { _B206 = value; } }
        public string B207 { get { return _B207; } set { _B207 = value; } }
        public string B208 { get { return _B208; } set { _B208 = value; } }
        public string B209 { get { return _B209; } set { _B209 = value; } }
        public string B210 { get { return _B210; } set { _B210 = value; } }

        // ── DD (ddvalues) properties ──
        public string DD1 { get { return _DD1; } set { _DD1 = value; } }
        public string DD2 { get { return _DD2; } set { _DD2 = value; } }
        public string DD3 { get { return _DD3; } set { _DD3 = value; } }
        public string DD4 { get { return _DD4; } set { _DD4 = value; } }
        public string DD5 { get { return _DD5; } set { _DD5 = value; } }
        public string DD6 { get { return _DD6; } set { _DD6 = value; } }
        public string DD7 { get { return _DD7; } set { _DD7 = value; } }
        public string DD8 { get { return _DD8; } set { _DD8 = value; } }
        public string DD9 { get { return _DD9; } set { _DD9 = value; } }
        public string DD10 { get { return _DD10; } set { _DD10 = value; } }
        public string DD11 { get { return _DD11; } set { _DD11 = value; } }
        public string DD12 { get { return _DD12; } set { _DD12 = value; } }
        public string DD13 { get { return _DD13; } set { _DD13 = value; } }
        public string DD14 { get { return _DD14; } set { _DD14 = value; } }
        public string DD15 { get { return _DD15; } set { _DD15 = value; } }
        public string DD16 { get { return _DD16; } set { _DD16 = value; } }
        public string DD17 { get { return _DD17; } set { _DD17 = value; } }
        public string DD18 { get { return _DD18; } set { _DD18 = value; } }
        public string DD19 { get { return _DD19; } set { _DD19 = value; } }
        public string DD20 { get { return _DD20; } set { _DD20 = value; } }
        public string DD21 { get { return _DD21; } set { _DD21 = value; } }
        public string DD22 { get { return _DD22; } set { _DD22 = value; } }
        public string DD23 { get { return _DD23; } set { _DD23 = value; } }
        public string DD24 { get { return _DD24; } set { _DD24 = value; } }
        public string DD25 { get { return _DD25; } set { _DD25 = value; } }
        public string DD26 { get { return _DD26; } set { _DD26 = value; } }
        public string DD27 { get { return _DD27; } set { _DD27 = value; } }
        public string DD28 { get { return _DD28; } set { _DD28 = value; } }
        public string DD29 { get { return _DD29; } set { _DD29 = value; } }
        public string DD30 { get { return _DD30; } set { _DD30 = value; } }
        public string DD31 { get { return _DD31; } set { _DD31 = value; } }
        public string DD32 { get { return _DD32; } set { _DD32 = value; } }
        public string DD33 { get { return _DD33; } set { _DD33 = value; } }
        public string DD34 { get { return _DD34; } set { _DD34 = value; } }
        public string DD35 { get { return _DD35; } set { _DD35 = value; } }
        public string DD36 { get { return _DD36; } set { _DD36 = value; } }
        public string DD37 { get { return _DD37; } set { _DD37 = value; } }
        public string DD38 { get { return _DD38; } set { _DD38 = value; } }
        public string DD39 { get { return _DD39; } set { _DD39 = value; } }
        public string DD40 { get { return _DD40; } set { _DD40 = value; } }
        public string DD41 { get { return _DD41; } set { _DD41 = value; } }
        public string DD42 { get { return _DD42; } set { _DD42 = value; } }
        public string DD43 { get { return _DD43; } set { _DD43 = value; } }
        public string DD44 { get { return _DD44; } set { _DD44 = value; } }
        public string DD45 { get { return _DD45; } set { _DD45 = value; } }
        public string DD46 { get { return _DD46; } set { _DD46 = value; } }
        public string DD47 { get { return _DD47; } set { _DD47 = value; } }
        public string DD48 { get { return _DD48; } set { _DD48 = value; } }
        public string DD49 { get { return _DD49; } set { _DD49 = value; } }
        public string DD50 { get { return _DD50; } set { _DD50 = value; } }
        public string DD51 { get { return _DD51; } set { _DD51 = value; } }
        public string DD52 { get { return _DD52; } set { _DD52 = value; } }
        public string DD53 { get { return _DD53; } set { _DD53 = value; } }
        public string DD54 { get { return _DD54; } set { _DD54 = value; } }
        public string DD55 { get { return _DD55; } set { _DD55 = value; } }
        public string DD56 { get { return _DD56; } set { _DD56 = value; } }
        public string DD57 { get { return _DD57; } set { _DD57 = value; } }
        public string DD58 { get { return _DD58; } set { _DD58 = value; } }
        public string DD59 { get { return _DD59; } set { _DD59 = value; } }
        public string DD60 { get { return _DD60; } set { _DD60 = value; } }
        public string DD61 { get { return _DD61; } set { _DD61 = value; } }
        public string DD62 { get { return _DD62; } set { _DD62 = value; } }
        public string DD63 { get { return _DD63; } set { _DD63 = value; } }
        public string DD64 { get { return _DD64; } set { _DD64 = value; } }
        public string DD65 { get { return _DD65; } set { _DD65 = value; } }
        public string DD66 { get { return _DD66; } set { _DD66 = value; } }
        public string DD67 { get { return _DD67; } set { _DD67 = value; } }
        public string DD68 { get { return _DD68; } set { _DD68 = value; } }
        public string DD69 { get { return _DD69; } set { _DD69 = value; } }
        public string DD70 { get { return _DD70; } set { _DD70 = value; } }
        public string DD71 { get { return _DD71; } set { _DD71 = value; } }
        public string DD72 { get { return _DD72; } set { _DD72 = value; } }
        public string DD73 { get { return _DD73; } set { _DD73 = value; } }
        public string DD74 { get { return _DD74; } set { _DD74 = value; } }
        public string DD75 { get { return _DD75; } set { _DD75 = value; } }
        public string DD76 { get { return _DD76; } set { _DD76 = value; } }
        public string DD77 { get { return _DD77; } set { _DD77 = value; } }
        public string DD78 { get { return _DD78; } set { _DD78 = value; } }
        public string DD79 { get { return _DD79; } set { _DD79 = value; } }
        public string DD80 { get { return _DD80; } set { _DD80 = value; } }
        public string DD81 { get { return _DD81; } set { _DD81 = value; } }
        public string DD82 { get { return _DD82; } set { _DD82 = value; } }
        public string DD83 { get { return _DD83; } set { _DD83 = value; } }
        public string DD84 { get { return _DD84; } set { _DD84 = value; } }
        public string DD85 { get { return _DD85; } set { _DD85 = value; } }
        public string DD86 { get { return _DD86; } set { _DD86 = value; } }
        public string DD87 { get { return _DD87; } set { _DD87 = value; } }
        public string DD88 { get { return _DD88; } set { _DD88 = value; } }
        public string DD89 { get { return _DD89; } set { _DD89 = value; } }
        public string DD90 { get { return _DD90; } set { _DD90 = value; } }
        public string DD91 { get { return _DD91; } set { _DD91 = value; } }
        public string DD92 { get { return _DD92; } set { _DD92 = value; } }
        public string DD93 { get { return _DD93; } set { _DD93 = value; } }
        public string DD94 { get { return _DD94; } set { _DD94 = value; } }
        public string DD95 { get { return _DD95; } set { _DD95 = value; } }
        public string DD96 { get { return _DD96; } set { _DD96 = value; } }
        public string DD97 { get { return _DD97; } set { _DD97 = value; } }
        public string DD98 { get { return _DD98; } set { _DD98 = value; } }
        public string DD99 { get { return _DD99; } set { _DD99 = value; } }
        public string DD100 { get { return _DD100; } set { _DD100 = value; } }
        public string DD101 { get { return _DD101; } set { _DD101 = value; } }
        public string DD102 { get { return _DD102; } set { _DD102 = value; } }
        public string DD103 { get { return _DD103; } set { _DD103 = value; } }
        public string DD104 { get { return _DD104; } set { _DD104 = value; } }
        public string DD105 { get { return _DD105; } set { _DD105 = value; } }
        public string DD106 { get { return _DD106; } set { _DD106 = value; } }
        public string DD107 { get { return _DD107; } set { _DD107 = value; } }
        public string DD108 { get { return _DD108; } set { _DD108 = value; } }
        public string DD109 { get { return _DD109; } set { _DD109 = value; } }
        public string DD110 { get { return _DD110; } set { _DD110 = value; } }
        public string DD111 { get { return _DD111; } set { _DD111 = value; } }
        public string DD112 { get { return _DD112; } set { _DD112 = value; } }
        public string DD113 { get { return _DD113; } set { _DD113 = value; } }
        public string DD114 { get { return _DD114; } set { _DD114 = value; } }
        public string DD115 { get { return _DD115; } set { _DD115 = value; } }
        public string DD116 { get { return _DD116; } set { _DD116 = value; } }
        public string DD117 { get { return _DD117; } set { _DD117 = value; } }
        public string DD118 { get { return _DD118; } set { _DD118 = value; } }
        public string DD119 { get { return _DD119; } set { _DD119 = value; } }
        public string DD120 { get { return _DD120; } set { _DD120 = value; } }
        public string DD121 { get { return _DD121; } set { _DD121 = value; } }
        public string DD122 { get { return _DD122; } set { _DD122 = value; } }
        public string DD123 { get { return _DD123; } set { _DD123 = value; } }
        public string DD124 { get { return _DD124; } set { _DD124 = value; } }
        public string DD125 { get { return _DD125; } set { _DD125 = value; } }
        public string DD126 { get { return _DD126; } set { _DD126 = value; } }
        public string DD127 { get { return _DD127; } set { _DD127 = value; } }
        public string DD128 { get { return _DD128; } set { _DD128 = value; } }
        public string DD129 { get { return _DD129; } set { _DD129 = value; } }
        public string DD130 { get { return _DD130; } set { _DD130 = value; } }
        public string DD131 { get { return _DD131; } set { _DD131 = value; } }
        public string DD132 { get { return _DD132; } set { _DD132 = value; } }
        public string DD133 { get { return _DD133; } set { _DD133 = value; } }
        public string DD134 { get { return _DD134; } set { _DD134 = value; } }
        public string DD135 { get { return _DD135; } set { _DD135 = value; } }
        public string DD136 { get { return _DD136; } set { _DD136 = value; } }
        public string DD137 { get { return _DD137; } set { _DD137 = value; } }
        public string DD138 { get { return _DD138; } set { _DD138 = value; } }
        public string DD139 { get { return _DD139; } set { _DD139 = value; } }
        public string DD140 { get { return _DD140; } set { _DD140 = value; } }
        public string DD141 { get { return _DD141; } set { _DD141 = value; } }
        public string DD142 { get { return _DD142; } set { _DD142 = value; } }
        public string DD143 { get { return _DD143; } set { _DD143 = value; } }
        public string DD144 { get { return _DD144; } set { _DD144 = value; } }
        public string DD145 { get { return _DD145; } set { _DD145 = value; } }
        public string DD146 { get { return _DD146; } set { _DD146 = value; } }
        public string DD147 { get { return _DD147; } set { _DD147 = value; } }
        public string DD148 { get { return _DD148; } set { _DD148 = value; } }
        public string DD149 { get { return _DD149; } set { _DD149 = value; } }
        public string DD150 { get { return _DD150; } set { _DD150 = value; } }
        public string DD151 { get { return _DD151; } set { _DD151 = value; } }
        public string DD152 { get { return _DD152; } set { _DD152 = value; } }
        public string DD153 { get { return _DD153; } set { _DD153 = value; } }
        public string DD154 { get { return _DD154; } set { _DD154 = value; } }
        public string DD155 { get { return _DD155; } set { _DD155 = value; } }
        public string DD156 { get { return _DD156; } set { _DD156 = value; } }
        public string DD157 { get { return _DD157; } set { _DD157 = value; } }
        public string DD158 { get { return _DD158; } set { _DD158 = value; } }
        public string DD159 { get { return _DD159; } set { _DD159 = value; } }
        public string DD160 { get { return _DD160; } set { _DD160 = value; } }
        public string DD161 { get { return _DD161; } set { _DD161 = value; } }
        public string DD162 { get { return _DD162; } set { _DD162 = value; } }
        public string DD163 { get { return _DD163; } set { _DD163 = value; } }
        public string DD164 { get { return _DD164; } set { _DD164 = value; } }
        public string DD165 { get { return _DD165; } set { _DD165 = value; } }
        public string DD166 { get { return _DD166; } set { _DD166 = value; } }
        public string DD167 { get { return _DD167; } set { _DD167 = value; } }
        public string DD168 { get { return _DD168; } set { _DD168 = value; } }
        public string DD169 { get { return _DD169; } set { _DD169 = value; } }
        public string DD170 { get { return _DD170; } set { _DD170 = value; } }
        public string DD171 { get { return _DD171; } set { _DD171 = value; } }
        public string DD172 { get { return _DD172; } set { _DD172 = value; } }
        public string DD173 { get { return _DD173; } set { _DD173 = value; } }
        public string DD174 { get { return _DD174; } set { _DD174 = value; } }
        public string DD175 { get { return _DD175; } set { _DD175 = value; } }
        public string DD176 { get { return _DD176; } set { _DD176 = value; } }
        public string DD177 { get { return _DD177; } set { _DD177 = value; } }
        public string DD178 { get { return _DD178; } set { _DD178 = value; } }
        public string DD179 { get { return _DD179; } set { _DD179 = value; } }
        public string DD180 { get { return _DD180; } set { _DD180 = value; } }
        public string DD181 { get { return _DD181; } set { _DD181 = value; } }
        public string DD182 { get { return _DD182; } set { _DD182 = value; } }
        public string DD183 { get { return _DD183; } set { _DD183 = value; } }
        public string DD184 { get { return _DD184; } set { _DD184 = value; } }
        public string DD185 { get { return _DD185; } set { _DD185 = value; } }
        public string DD186 { get { return _DD186; } set { _DD186 = value; } }
        public string DD187 { get { return _DD187; } set { _DD187 = value; } }
        public string DD188 { get { return _DD188; } set { _DD188 = value; } }
        public string DD189 { get { return _DD189; } set { _DD189 = value; } }
        public string DD190 { get { return _DD190; } set { _DD190 = value; } }
        public string DD191 { get { return _DD191; } set { _DD191 = value; } }
        public string DD192 { get { return _DD192; } set { _DD192 = value; } }
        public string DD193 { get { return _DD193; } set { _DD193 = value; } }
        public string DD194 { get { return _DD194; } set { _DD194 = value; } }
        public string DD195 { get { return _DD195; } set { _DD195 = value; } }
        public string DD196 { get { return _DD196; } set { _DD196 = value; } }
        public string DD197 { get { return _DD197; } set { _DD197 = value; } }
        public string DD198 { get { return _DD198; } set { _DD198 = value; } }
        public string DD199 { get { return _DD199; } set { _DD199 = value; } }
        public string DD200 { get { return _DD200; } set { _DD200 = value; } }
        public string DD201 { get { return _DD201; } set { _DD201 = value; } }
        public string DD202 { get { return _DD202; } set { _DD202 = value; } }
        public string DD203 { get { return _DD203; } set { _DD203 = value; } }
        public string DD204 { get { return _DD204; } set { _DD204 = value; } }
        public string DD205 { get { return _DD205; } set { _DD205 = value; } }
        public string DD206 { get { return _DD206; } set { _DD206 = value; } }
        public string DD207 { get { return _DD207; } set { _DD207 = value; } }
        public string DD208 { get { return _DD208; } set { _DD208 = value; } }
        public string DD209 { get { return _DD209; } set { _DD209 = value; } }
        public string DD210 { get { return _DD210; } set { _DD210 = value; } }








       
    }
}
