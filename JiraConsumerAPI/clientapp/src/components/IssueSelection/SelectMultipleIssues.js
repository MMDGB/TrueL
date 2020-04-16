import React, { Component } from "react";
import TextField from '@material-ui/core/TextField';
import Autocomplete, { createFilterOptions } from '@material-ui/lab/Autocomplete';
import * as repositoryActions from '../../store/actions/repositoryActions'
import { connect } from 'react-redux'

const filter = createFilterOptions();

class SelectMultipleIssues extends Component {

    render() {
        var arr = [];
        return (
            <React.Fragment>
                <Autocomplete
                    multiple
                    id="tags-standard"
                    options={issues}
                    onChange={
                        (event, value) => {
                            let arr = []
                            for(let item of value)
                                arr.push(item.title)
                            this.props.setIssueList(arr)
                        }
                    }
                    filterOptions={(options, params) => {
                        const filtered = filter(options, params);

                        if (params.inputValue !== '') {
                            filtered.push({
                                inputValue: params.inputValue,
                                title: `${params.inputValue}`,
                            });
                        }

                        return filtered;
                    }}
                    getOptionLabel={option => option.title + '  (  ' + option.comment + ' )'}
                    style={{ width: 300 }}
                    renderInput={params => (
                        <TextField
                            {...params}
                            variant="standard"
                            label="Multiple values"
                            placeholder="Favorites"
                        />
                    )}
                />
            </React.Fragment>
        );
    }
}

const issues = [
    { title: 'TIS-94', comment: 'Defect - Warranty SAFiR '  },
    { title: 'TIS-98', comment: 'Change Request - Maintenance FEPLAS'  },
    { title: 'TIS-85', comment: 'Change Request - Maintenance FiNAS '  },
    { title: 'TIS-399', comment: 'Change Request - Maintenance SAFiR'  },
    { title: 'TIS-398', comment: 'Defect - Warranty FEPLAS'  },
    { title: 'TIS-112', comment: 'Defect - Warranty FiNAS' },
    { title: 'TIS-121', comment: 'TIS Onboarding' },
    { title: 'TIS-126', comment: 'TIS Meeting' },
    { title: 'TIS-127', comment: 'TIS - Analysis and estimation' },
    { title: 'TIS-194', comment: 'TIS - Support'  },
    { title: 'TIS-302', comment: 'TIS-SVN trunk and branches(Configuration web/client/server application)'  },
    { title: 'TIS-45', comment: 'FiNAS  Translation'  },
    { title: 'TIS-46', comment: 'SAFiR  Translation'  },
    { title: 'TIS-47', comment: 'FEPLAS Translation'  },
    { title: 'TIS-521', comment: 'WAS EAR deploy'  },
    { title: 'TIS-575', comment: 'TIS - Development and learning opportunities'  },
    { title: 'TIS-620', comment: 'Autotest SAFiR '  },
    { title: 'TIS-860', comment: '20.03 - Testing of #116384[SGV_029/SGV_030/SGV_031/SGV_032/SGV_033/SGV_034/SGV_035/SGV_036/SGV_037/SGV_038/SGV_039/SGV_040]'  },
    { title: 'TIS-872', comment: '20.07 - Implementation of ES-45 (FE91497) –  Ablage von Dokumenten zu FEPLAS Verträgen (Storage of documents for FEPLAS contracts)'  },
    { title: 'TIS-873', comment: '20.07 - Testing of ES-45 (FE91497) –  Ablage von Dokumenten zu FEPLAS Verträgen (Storage of documents for FEPLAS contracts)'  },
    { title: 'TIS-882', comment: '20.07 - Implemenation of ES-104 –  WebService for the storage of documents in the FEPLAS database'  },
    { title: 'TIS-883', comment: '20.07 - Testing of ES-104 –  WebService for the storage of documents in the FEPLAS database'  },
    { title: 'TIS-90', comment: 'Autotest FiNAS'  },
    { title: 'TIS-913', comment: '20.03 - Implementation of ES-118 fzv_060 - Massenanlage von Fahrzeugen (Mass creation of vehicles)'  },
    { title: 'TIS-914', comment: '20.03 - Testing of ES-118 -  fzv_060 - Massenanlage von Fahrzeugen (Mass creation of vehicles)'  },
    { title: 'TIS-919', comment: '20.03 - Implementation of ES-116 Benachrichtigung für Termine'  },
    { title: 'TIS-920', comment: '20.03 - Testing of ES-116 Benachrichtigung für Termine'  },
    { title: 'TIS-922', comment: '20.03 - Implementation of ES-108 Service for documentation of location reports for objects'  },
    { title: 'TIS-928', comment: '20.03 - Implementation of ES-125 [FEV_032/FEV_001] – MB Graz Zusatzblatt bei Erprobungsfahrt mit blauem Kennzeichen'  },
    { title: 'TIS-931', comment: '20.03 - Implementation of ES-117 Object event message analog vehicle event message'  },
    { title: 'TIS-932', comment: '20.03 - Testing of ES-117 Object event message analog vehicle event message'  },
    { title: 'TIS-943', comment: '20.03 - Implementation of ES-46 (FE106893) –  RD China - Einsatz "papierloser FEPLAS Torprozess"'  },
    { title: 'TIS-944', comment: '20.03 - Testing of ES-46 (FE106893) –  RD China - Einsatz "papierloser FEPLAS Torprozess"'  },
    { title: 'TIS-963', comment: '[Bonus Hours] PoC Erprobung migration to Microservices'  },
    { title: 'TIS-968', comment: '20.07 - Implementation of ES-140 – Neuer generischer WebService für Valet Parking für den Dauerlauf'  },
    { title: 'TIS-969', comment: '20.07 - Testing of ES-140 – Neuer generischer WebService für Valet Parking für den Dauerlauf'  },
    { title: 'TIS-970', comment: '[New technology 2020] - Migrating WAS-Services “Stufe 2”'  },
    { title: 'TIS-971', comment: '[New technology 2020] - New Arch GUI REACT'  },
    { title: 'TIS-972', comment: 'AutotestIDE  2020'  },
    { title: 'TIS-976', comment: ' [New technology 2020] - Testing Migrating WAS-Services'  },
    { title: 'TIS-978', comment: '20.07 - Implementation of CR107142 - GO - Durchbuchen geänderter Fahrzeug-Bestellungen  scp_233 - Zyklischer Auftragsupdate GO'  },
    { title: 'TIS-979', comment: '20.07 - Testing of CR107142 - GO - Durchbuchen geänderter Fahrzeug-Bestellungen  scp_233 - Zyklischer Auftragsupdate GO'  },
    { title: 'TIS-980', comment: '[New technology 2020 - Service Feplas Web]'  },
    { title: 'TIS-981', comment: '[New technology 2020] - Migrating WAS-Services “Stufe 3”'  },
    { title: 'TIS-983', comment: '20.07 - Implementation of ES-26  FINAS/VEDOC/DAIVB:  FINAS-Service für VariantCodin'  },
    { title: 'TIS-985', comment: '[New technology 2020] - Migrating WAS-Services “Stufe 1”'  }
];


const mapStateToProps = (state) => {
    return {
        data: state
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        setIssueList: (value) => dispatch(repositoryActions.setIssueList(value)),
    }
}
export default connect(mapStateToProps, mapDispatchToProps)(SelectMultipleIssues);

