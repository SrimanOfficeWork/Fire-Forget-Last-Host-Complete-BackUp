function SB_Status(Sbno, Sbdate, Port, mode) {
     var PortName;
    if (mode == 'Air') {
        if (Port == 'INAMD4') {
            PortName = 'AHEMDABAD AIR ACC (INAMD4)';
        }
        else if (Port == 'INATQ4') {
            PortName = 'AMRITSAR ACC (INATQ4)';
        }
        else if (Port == 'INBLR4') {
            PortName = 'BANGALORE ACC (INBLR4)';
        }
        else if (Port == 'INBBI4') {
            PortName = 'BHUBANESWAR AIR CARGO (INBBI4)';
        }
        else if (Port == 'INCCJ4') {
            PortName = 'CALICUT ACC (INCCJ4)';
        }
        else if (Port == 'INMAA4') {
            PortName = 'CHENNAI AIR CARGO ACC (INMAA4)';
        }
        else if (Port == 'INCOK4') {
            PortName = 'COCHIN AIR CARGO ACC (INCOK4)';
        }
        else if (Port == 'INCJB4') {
            PortName = 'COIMBATORE ACC (INCJB4)';
        }
        else if (Port == 'INDEL4') {
            PortName = 'DELHI AIR CARGO ACC (INDEL4)';
        }
        else if (Port == 'INGOI4') {
            PortName = 'GOA ACC (INGOI4)';
        }
        else if (Port == 'INGAU4') {
            PortName = 'GUWAHATI AIR CARGO (INGAU4))';
        }

        else if (Port == 'INHYD4') {
            PortName = 'HYDERABAD ACC (INHYD4)';
        }
        else if (Port == 'INIDR4') {
            PortName = 'INDORE ACC (INIDR4)';
        }
        else if (Port == 'INJAI4') {
            PortName = 'JAIPUR ACC (INJAI4)';
        }
        else if (Port == 'INJNR4') {
            PortName = 'JANORI ACC (INJNR4)';
        }
        else if (Port == 'INCCU4') {
            PortName = 'KOLKATA ACC (INCCU4)';
        }
        else if (Port == 'INJGA4') {
            PortName = 'JAMNAGAR AIR CARGO (INJGA4)';
        }
        else if (Port == 'INLKO4') {
            PortName = 'LUCKNOW AIR CARGO (INLKO4)';
        }
        else if (Port == 'INLOK4') {
            PortName = 'LUCKNOW AIR CARGO (INLOK4)';
        }
        else if (Port == 'INIXM4') {
            PortName = 'MADURAI AIR CARGO (INIXM4)';
        }
        else if (Port == 'INIXE4') {
            PortName = 'MANGALORE AIR CARGO (INIXE4)';
        }
        else if (Port == 'INNAG4') {
            PortName = 'NAGPUR AIR CARGO (INNAG4)';
        }
        else if (Port == 'INDPC4') {
            PortName = 'PCCCC BANDRA-KURLA COMPLEX (INDPC4)';
        }
        else if (Port == 'INPNQ4') {
            PortName = 'PUNE AIR CARGO (INPNQ4)';
        }
        else if (Port == 'INBOM4') {
            PortName = 'SAHAR AIR CARGO ACC (INBOM4)';
        }
        else if (Port == 'INSXR4') {
            PortName = 'SRINAGAR AIR CARGO (INSXR4)';
        }
        else if (Port == 'INTRZ4') {
            PortName = 'TIRUCHIRAPALLI AIR CARGO (INTRZ4)';
        }
        else if (Port == 'INTRV4') {
            PortName = 'TRIVANDRUM ACC (INTRV4)';
        }
        else if (Port == 'INVNS4') {
            PortName = 'VARANASI AIR CARGO (INVNS4)';
        }
        else if (Port == 'INVTZ4') {
            PortName = 'VISHAKHAPATNAM AIR CARGO (INVTZ4)';
        }
   
   
    }
    else if (mode == 'Sea') {

        if (Port == 'INALA1') {
            PortName = 'ALANG SEA (INALA1)';
        }
        else if (Port == 'INAZK1') {
            PortName = 'AZHIKKAL PORT (INAZK1)';
        }
        else if (Port == 'INBKT1') {
            PortName = 'BANKOT PORT (INBKT1)';
        }
        else if (Port == 'INBED1') {
            PortName = 'BEDI PORT SEA (INBED1)';
        }
        else if (Port == 'INBEY1') {
            PortName = 'BEYPORE PORT (INBEY1)';
        }
        else if (Port == 'INBHU1') {
            PortName = 'BHAVNAGAR SEA (INBHU1)';
        }
        else if (Port == 'INMAA1') {
            PortName = 'CHENNAI SEA (INMAA1)';
        }
        else if (Port == 'INCOK1') {
            PortName = 'COCHIN SEA (INCOK1)';
        }
        else if (Port == 'INCDL1') {
            PortName = 'CUDDALORE PORT (INCDL1)';
        }
        else if (Port == 'INDHP1') {
            PortName = 'DABHOL PORT (INDHP1)';
        }
        else if (Port == 'INDAH1') {
            PortName = 'DAHEJ PORT SEA (INDAH1)';
        }
        else if (Port == 'INDHU1') {
            PortName = 'DHAHANU PORT (INDHU1)';
        }
        else if (Port == 'INDMA1') {
            PortName = 'DHAMRA PORT SEA (INDMA1)';
        }
        else if (Port == 'INDMT1') {
            PortName = 'DHARMATAR PORT MUMBAI (INDMT1)';
        }
        else if (Port == 'INDIG1') {
            PortName = 'DIGHI PORT (INDIG1)';
        }
        else if (Port == 'INENR1') {
            PortName = 'ENNOR PORT SEA (INENR1)';
        }
        else if (Port == 'INGGV1') {
            PortName = 'GANGAVARAM PORT SEA (INGGV1)';
        }
        else if (Port == 'INMRM1') {
            PortName = 'GOA PORT SEA (INMRM1)';
        }
        else if (Port == 'INGPR1') {
            PortName = 'GOPALPUR PORT (INGPR1)';
        }
        else if (Port == 'INHZA1') {
            PortName = 'HAZIRA PORT SURAT (INHZA1)';
        }
        else if (Port == 'INJGD1') {
            PortName = 'JAIGARH PORT MAHARASHTRA (INJGD1)';
        }
        else if (Port == 'INJAK1') {
            PortName = 'JAKHAU PORT (INJAK1)';
        }
        else if (Port == 'INKAK1') {
            PortName = 'KAKINADA SEA (INKAK1)';
        }
        else if (Port == 'INKRK1') {
            PortName = 'KARAIKAL SEA PORT (INKRK1)';
        }
        else if (Port == 'INIXY1') {
            PortName = 'KANDLA SEA (INIXY1)';
        }
        else if (Port == 'INKRW1') {
            PortName = 'KARWAR PORT (INKRW1)';
        }
        else if (Port == 'INKAT1') {
            PortName = 'KATTUPALLI PORT SEA (INKAT1)';
        }
        else if (Port == 'INKSH1') {
            PortName = 'KELSHI PORT (INKSH1)';
        }
        else if (Port == 'INKDN1') {
            PortName = 'KODINAR PORT (INKDN1)';
        }
        else if (Port == 'INCCU1') {
            PortName = 'KOLKATA SEA (INCCU1)';
        }
        else if (Port == 'INKUK1') {
            PortName = 'KOLLAM PORT SEA (INKUK1)';
        }
        else if (Port == 'INKRI1') {
            PortName = 'KRISHNAPATNAM PORT SEA (INKRI1)';
        }
        else if (Port == 'INMDA1') {
            PortName = 'MAGDALA PORT SEA (INMDA1)';
        }
        else if (Port == 'INNML1') {
            PortName = 'MANGALORE SEA (INNML1)';
        }
        else if (Port == 'INBOM1') {
            PortName = 'MUMBAI CUSTOM HOUSE SEA (INBOM1)';
        }
        else if (Port == 'INMUN1') {
            PortName = 'MUNDRA SEA (INMUN1)';
        }
        else if (Port == 'INNPT1') {
            PortName = 'NAGAPATTINAM CUSTOM HOUSE SEA (INNPT1)';
        }
        else if (Port == 'INNAV1') {
            PortName = 'NAVLAKHI PORT (INNAV1)';
        }
        else if (Port == 'INNSA1') {
            PortName = 'NHAVA SHEVA SEA (INNSA1)';
        }
        else if (Port == 'INOKH1') {
            PortName = 'OKHA PORT (INOKH1)';
        }
        else if (Port == 'INIXE1') {
            PortName = 'OLD MANGALORE PORT (INIXE1)';
        }
        else if (Port == 'INOMU1') {
            PortName = 'OLD MUNDRA PORT (INOMU1)';
        }
        else if (Port == 'INPAN1') {
            PortName = 'PANAJI PORT (INPAN1)';
        }
        else if (Port == 'INPRT1') {
            PortName = 'PARADEEP PORT SEA (INPRT1)';
        }
        else if (Port == 'INPAV1') {
            PortName = 'PIPAVAV - VICTOR PORT GUJARAT SEA (INPAV1)';
        }
        else if (Port == 'INPNY1') {
            PortName = 'PONDICHERRY CUSTOM HOUSE SEA (INPNY1)';
        }
        else if (Port == 'INPBD1') {
            PortName = 'PORBANDAR PORT (INPBD1)';
        }
        else if (Port == 'INRNR1') {
            PortName = 'RANPAR PORT RATNAGIRI MAHARASHTRA (INRNR1)';
        }
        else if (Port == 'INRED1') {
            PortName = 'REDI PORT (INRED1)';
        }
        else if (Port == 'INRVD1') {
            PortName = 'REVDANDA PORT (INRVD1)';
        }
        else if (Port == 'INSIK1') {
            PortName = 'SIKKA PORT (INSIK1)';
        }
        else if (Port == 'INTUN1') {
            PortName = 'TUNA PORT (INTUN1)';
        }
        else if (Port == 'INTUT1') {
            PortName = 'TUTICORIN SEA (INTUT1)';
        }
        else if (Port == 'INVAD1') {
            PortName = 'VADINAR PORT (INVAD1)';
        }
        else if (Port == 'INVYD1') {
            PortName = 'VIJAYDURG PORT (INVYD1)';
        }
        else if (Port == 'INVTZ1') {
            PortName = 'VIZAG SEA (INVTZ1)';
        }
        else if (Port == 'INVZJ1') {
            PortName = 'VIZHINJAM PORT (INVZJ1)';
        }
    }
    else if (mode == 'Land') {

        if (Port == 'INBLJ6') {
            PortName = 'AGRA ICD (INBLJ6)';
        }
        else if (Port == 'INSBI6') {
            PortName = 'AHEMDABAD ICD (INSBI6)';
        }
        else if (Port == 'INAPL6') {
            PortName = 'ALBRATOS CFS PVT. LTD. ICD (INAPL6)';
        }
        else if (Port == 'INAMG6') {
            PortName = 'AMINGAON ICD (INAMG6)';
        }
        else if (Port == 'INAKV6') {
            PortName = 'ANKALESHWAR ICD (INAKV6)';
        }
        else if (Port == 'INAJJ6') {
            PortName = 'ARAKKANOM ICD (INAJJ6)';
        }
        else if (Port == 'INBDI6') {
            PortName = 'BADDI ICD (INBDI6)';
        }
        else if (Port == 'INBLE6') {
            PortName = 'BALASORE Concor ICD (INBLE6)';
        }
        else if (Port == 'INBVC6') {
            PortName = 'BALLABGARH CONCOR ICD (INBVC6)';
        }
        else if (Port == 'INFBD6') {
            PortName = 'BALLABGARH ICD (INFBD6)';
        }
        else if (Port == 'INWFD6') {
            PortName = 'BANGALORE ICD (INWFD6)';
        }
        else if (Port == 'INRUG6') {
            PortName = 'BARHI ICD (INRUG6)';
        }
        else if (Port == 'INBAW6') {
            PortName = 'BAWAL ICD (INBAW6)';
        }
        else if (Port == 'INGRW6') {
            PortName = 'BHAMBOLI ICD (INGRW6)';
        }
        else if (Port == 'INBHL6') {
            PortName = 'BHILWARA ICD (INBHL6)';
        }
        else if (Port == 'INBWD6') {
            PortName = 'BHIWADI ICD (INBWD6)';
        }
        else if (Port == 'INBSL6') {
            PortName = 'BHUSAWAL ICD (INBSL6)';
        }
        else if (Port == 'INBOK6') {
            PortName = 'BORKHEDI ICD (INBOK6)';
        }
        else if (Port == 'INNGB6') {
            PortName = 'BUTIBORI ICD (INNGB6)';
        }
        else if (Port == 'INNSK6') {
            PortName = 'CFS NASIK ICD (INNSK6)';
        }
        else if (Port == 'INCPC6') {
            PortName = 'CHAKERI KANPUR ICD (INCPC6)';
        }
        else if (Port == 'INCPR6') {
            PortName = 'CHAWAPAYAL ICD (INCPR6)';
        }
        else if (Port == 'INASR6') {
            PortName = 'CHEHERTA ICD (INASR6)';
        }
        else if (Port == 'INCHE6') {
            PortName = 'CHETTIPALAYM ICD (INCHE6)';
        }
        else if (Port == 'INCCH6') {
            PortName = 'CHINCHWAD PUNE ICD (INCCH6)';
        }
        else if (Port == 'INCPL6') {
            PortName = 'CMA CGM LOGISTICS PARK ICD (INCPL6)';
        }
        else if (Port == 'INJSG6') {
            PortName = 'CONCOR ICD JHARSUGUDA (INJSG6)';
        }
        else if (Port == 'INBGK6') {
            PortName = 'CONCOR JODHPUR ICD (INBGK6)';
        }
        else if (Port == 'INNJP6') {
            PortName = 'DABGRAM ICD (INNJP6)';
        }
        else if (Port == 'INDER6') {
            PortName = 'DADRI ICD (INDER6)';
        }
        else if (Port == 'INDAH1') {
            PortName = 'DAHEJ PORT SEA (INDAH1)';
        }
        else if (Port == 'INDPR6') {
            PortName = 'DAPPAR ICD (INDPR6)';
        }
        else if (Port == 'INDRGB') {
            PortName = 'DARRANGA LCS (INDRGB)';
        }
        else if (Port == 'INBRC6') {
            PortName = 'DASHRATH VADODRA ICD (INBRC6)';
        }
        else if (Port == 'INDRU6') {
            PortName = 'DESUR ICD (INDRU6)';
        }
        else if (Port == 'INDHA6') {
            PortName = 'DHANNAD ICD (INDHA6)';
        }
        else if (Port == 'INDIG6') {
            PortName = 'DIGHI ICD (INDIG6)';
        }
        else if (Port == 'INDUR6') {
            PortName = 'DURGAPUR ICD (INDUR6)';
        }
        else if (Port == 'INGHR6') {
            PortName = 'GARI HARSARU ICD (INGHR6)';
        }
        else if (Port == 'INPNY6') {
            PortName = 'GFPULICHAPALLAM ICD (INPNY6)';
        }
        else if (Port == 'INSGF6') {
            PortName = 'GRFL SAHNEWAL LUDHIANA ICD (INSGF6)';
        }
        else if (Port == 'INHIR6') {
            PortName = 'HIRA BORUSE SURAT ICD (INHIR6)';
        }
        else if (Port == 'INHSU6') {
            PortName = 'HOSUR ICD (INHSU6)';
        }
        else if (Port == 'INSNF6') {
            PortName = 'HYDERABAD ICD (INSNF6)';
        }
        else if (Port == 'INLDH6') {
            PortName = 'ICD CONCOR DHANDARI KALAN LUDHIANA (INLDH6)';
        }
        else if (Port == 'INHAS6') {
            PortName = 'ICD HASSAN (INHAS6)';
        }
        else if (Port == 'INPRK6') {
            PortName = 'ICD POWARKHEDA (INPRK6)';
        }
        else if (Port == 'INIGU6') {
            PortName = 'IRUGUR ICD (INIGU6)';
        }
        else if (Port == 'INILP6') {
            PortName = 'IRUNGATTUKOTTAI ICD (INILP6)';
        }
        else if (Port == 'INJAI6') {
            PortName = 'JAIPUR ICD (INJAI6)';
        }
        else if (Port == 'INJJK6') {
            PortName = 'JAJPUR ICD (INJJK6)';
        }
        else if (Port == 'INJUC6') {
            PortName = 'JALANDHAR ICD (INJUC6)';
        }
        else if (Port == 'INIXW6') {
            PortName = 'JAMSHEDPUR ICD (INIXW6)';
        }
        else if (Port == 'INJNR6') {
            PortName = 'JANORI ICD (INJNR6)';
        }
        else if (Port == 'INDWN6') {
            PortName = 'JATTIPUR ICD (INDWN6)';
        }
        else if (Port == 'INKNU6') {
            PortName = 'JRY KANPUR ICD (INKNU6)';
        }
        else if (Port == 'INSKD6') {
            PortName = 'KALINGANAGAR ICD (INSKD6)';
        }
        else if (Port == 'INKKU6') {
            PortName = 'KANAKPURA ICD (INKKU6)';
        }
        else if (Port == 'INSNI6') {
            PortName = 'KANECH SAHNEWAL ICD (INSNI6)';
        }
        else if (Port == 'INKAR6') {
            PortName = 'KARUR ICD (INKAR6)';
        }
        else if (Port == 'INHPI6') {
            PortName = 'KASHIPUR ICD (INHPI6)';
        }
        else if (Port == 'INMDU6') {
            PortName = 'KERN ICD MADURAI (INMDU6)';
        }
        else if (Port == 'INCML6') {
            PortName = 'KHATUWAS ICD (INCML6)';
        }
        else if (Port == 'INKHD6') {
            PortName = 'KHEDA ICD (INKHD6)';
        }
        else if (Port == 'INAIK6') {
            PortName = 'KHURJA ICD (INAIK6)';
        }
        else if (Port == 'INQRP6') {
            PortName = 'KILARAIPUR ADANI ICD (INQRP6)';
        }
        else if (Port == 'INQRH6') {
            PortName = 'HTPL ICD KILARAIPUR (INQRH6)';
        }
        else if (Port == 'INKTT6') {
            PortName = 'KOTA ICD (INKTT6) ';
        }
        else if (Port == 'INKYM6') {
            PortName = 'KOTTAYAM ICD (INKYM6)';
        }
        else if (Port == 'INKBC6') {
            PortName = 'KRIBHCO SURAT ICD (INKBC6)';
        }
        else if (Port == 'INLON6') {
            PortName = 'LONI ICD (INLON6)';
        }
        else if (Port == 'INMBS6') {
            PortName = 'MADHOSINGH ICD (INMBS6)';
        }
        else if (Port == 'INMPR6') {
            PortName = 'MALANPUR ICD (INMPR6)';
        }
        else if (Port == 'INMWA6') {
            PortName = 'MALIWADA ICD (INMWA6)';
        }
        else if (Port == 'INMDD6') {
            PortName = 'MANDIDEEP ICD (INMDD6)';
        }
        else if (Port == 'INGNR6') {
            PortName = 'MARRIPALAM ICD (INGNR6)';
        }
        else if (Port == 'INKPK6') {
            PortName = 'MIHAN ICD (INKPK6)';
        }
        else if (Port == 'INMUZ6') {
            PortName = 'MODINAGAR ICD (INMUZ6)';
        }
        else if (Port == 'INMUL6') {
            PortName = 'MULUND ICD (INMUL6)';
        }
        else if (Port == 'INNGP6') {
            PortName = 'NAGPUR ICD (INNGP6)';
        }
        else if (Port == 'INRML6') {
            PortName = 'NAYA RAIPUR CONCOR ICD (INRML6)';
        }
        else if (Port == 'INMBD6') {
            PortName = 'PAKWARA MORADABAD ICD (INMBD6)';
        }
        else if (Port == 'INPKR6') {
            PortName = 'PALI ICD REWARI (INPKR6)';
        }
        else if (Port == 'INPWL6') {
            PortName = 'PALWAL ICD (INPWL6)';
        }
        else if (Port == 'INPNP6') {
            PortName = 'PANIPAT ICD (INPNP6)';
        }
        else if (Port == 'INPNK6') {
            PortName = 'PANKI ICD (INPNK6)';
        }
        else if (Port == 'INHDD6') {
            PortName = 'PANTNAGAR ICD (INHDD6)';
        }
        else if (Port == 'INPTL6') {
            PortName = 'PATLI ICD (INPTL6)';
        }
        else if (Port == 'INPPG6') {
            PortName = 'PATPARGANJ ICD (INPPG6)';
        }
        else if (Port == 'INPMP6') {
            PortName = 'PIMPRI ICD (INPMP6)';
        }
        else if (Port == 'ININD6') {
            PortName = 'PITHAMPUR ICD (ININD6)';
        }
        else if (Port == 'INBFR6') {
            PortName = 'PIYALA ICD (INBFR6)';
        }
        else if (Port == 'INSLL6') {
            PortName = 'PORT SINGANALLUR ICD (INSLL6)';
        }
        else if (Port == 'INDDL6') {
            PortName = 'PSWC DHANDARI KALAN LUDHIANA (INDDL6)';
        }
        else if (Port == 'INTUP6') {
            PortName = 'RAAKIYAPALAYAM ICD (INTUP6)';
        }
        else if (Port == 'INRAI6') {
            PortName = 'RAIPUR ICD (INRAI6)';
        }
        else if (Port == 'INJUX6') {
            PortName = 'RAJSICO BASNI JODNPUR ICD (INJUX6)';
        }
        else if (Port == 'INRTM6') {
            PortName = 'RATLAM ICD (INRTM6)';
        }
        else if (Port == 'INRVD1') {
            PortName = 'REVDANDA PORT (INRVD1)';
        }
        else if (Port == 'INREA6') {
            PortName = 'REWARI ICD (INREA6)';
        }
        else if (Port == 'INJKA6') {
            PortName = 'SACHANA ICD (INJKA6)';
        }
        else if (Port == 'INSAC6') {
            PortName = 'SACHIN ICD (INSAC6)';
        }
        else if (Port == 'INKQZ6') {
            PortName = 'SATTVA BENGALURU ICD (INKQZ6)';
        }
        else if (Port == 'INBDM6') {
            PortName = 'SONEPAT ICD (INBDM6)';
        }
        else if (Port == 'INSTT6') {
            PortName = 'STARTRACK TERMINAL ICD (INSTT6)';
        }
        else if (Port == 'INTLG6') {
            PortName = 'TALEGAON PUNE ICD (INTLG6)';
        }
        else if (Port == 'INBNG6') {
            PortName = 'TARAPUR ICD (INBNG6)';
        }
        else if (Port == 'INSAU6') {
            PortName = 'THAR DRY PORT ICD/AHMEDABAD GUJARAT ICD (INSAU6)';
        }
        else if (Port == 'INTHA6') {
            PortName = 'THAR DRY PORT JODHPUR ICD (INTHA6)';
        }
        else if (Port == 'INTMX6') {
            PortName = 'THIMMAPUR ICD (INTMX6)';
        }
        else if (Port == 'INTCR6') {
            PortName = 'THRISSUR ICD (INTCR6)';
        }
        else if (Port == 'INTDE6') {
            PortName = 'THUDIALUR ICD (INTDE6)';
        }
        else if (Port == 'INTVT6') {
            PortName = 'TONDIAPET ICD (INTVT6)';
        }
        else if (Port == 'INTTP6') {
            PortName = 'TRIDENT TERMINAL PVT. LTD. ICD (INTTP6)';
        }
        else if (Port == 'INTKD6') {
            PortName = 'TUGLAKABAD ICD (INTKD6)';
        }
        else if (Port == 'INSAJ6') {
            PortName = 'TUMB ICD (INSAJ6)';
        }
        else if (Port == 'INTUT6') {
            PortName = 'TUTICORIN ICD (INTUT6)';
        }
        else if (Port == 'INVPI6') {
            PortName = 'VAPI ICD (INVPI6)';
        }
        else if (Port == 'INTHO6') {
            PortName = 'VEERAPANDI ICD (INTHO6)';
        }
        else if (Port == 'INMDG6') {
            PortName = 'VERNA ICD (INMDG6)';
        }
        else if (Port == 'INVGR6') {
            PortName = 'VIRAMGAM ICD (INVGR6)';
        }
        else if (Port == 'INWAL6') {
            PortName = 'WALUJ ICD (INWAL6)';
        }
        else if (Port == 'INCHJ6') {
            PortName = 'WARDHA ICD (INCHJ6)';
        }
    }
    var title = "Royal Tech Systems";
    var igStat = window.open("", "", "height=600,width=1000,resizable=1,status=1,scrollbars=Yes");
    var html = "";
    var parameters = "{'SB_DT':'" + Sbdate + "','SB_NO':'" + Sbno + "','sbTrack_location':'" + PortName + "'}";
    var url = ' https://enquiry.icegate.gov.in/enquiryatices/sbTrack';

    html = ("<html><head><title>" + title + "</title></head><body style='margin:0;overflow:none;'>" +
								"<script type='text/javascript'> window.location.href=\"javascript:window.opener.post_Method(document,'" + url + "'," + parameters + ");\"; </script> " +
								"</body></html>");
    igStat.document.open();
    igStat.document.write(html);
    igStat.document.close();
    igStat.window.focus(); 

}

function post_Method(docObj, path, params, method) {
    method = method || "post"; 
    var formObj = docObj.createElement("form");
    formObj.setAttribute("method", method);
    formObj.setAttribute("action", path);

    for (var key in params) {
        var hiddenField = docObj.createElement("input");
        hiddenField.setAttribute("type", "hidden");
        hiddenField.setAttribute("name", key);
        hiddenField.setAttribute("value", params[key]);
        formObj.appendChild(hiddenField);
    }
    docObj.body.appendChild(formObj);
    formObj.submit();
};
