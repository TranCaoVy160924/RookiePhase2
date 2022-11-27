import React from 'react'
import { RadioButtonGroupInput } from 'react-admin'

function RadioButtonGroup(props) {
    return (
        <RadioButtonGroupInput 
            // fullwidth="true"
            {...props}
            sx={{
                ".PrivateSwitchBase-input + span":{
                    ".MuiSvgIcon-root:nth-child(1)" : {
                        width:"20px",
                        height:"20px",
                        color:'#000',
                        backgroundColor: '#fff',
                        borderRadius: '50%',
                    },
                    ".MuiSvgIcon-root:nth-child(2)":{
                        width:"20px",
                        height:"20px",
                        color:'#fff',
                    },
                },
                ".PrivateSwitchBase-input:checked + span ":{
                    ".MuiSvgIcon-root:nth-child(1)":{
                    width:"20px",
                    height:"20px",
                    color:'#cf2338',
                    backgroundColor: '#cf2338',
                    borderRadius: '50%',
                    },
                    ".MuiSvgIcon-root:nth-child(2)":{
                        width:"20px",
                        height:"20px",
                        color:'#fff',
                    }

                }
            }}
        />
    )
}

export default React.memo(RadioButtonGroup);