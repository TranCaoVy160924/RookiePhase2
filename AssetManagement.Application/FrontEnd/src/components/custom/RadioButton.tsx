import * as React from 'react';
import { styled } from '@mui/material/styles';
import Radio from '@mui/material/Radio';

const BpIcon = styled('span')(({ theme }) => ({
    borderRadius: '50%',
    width: 16,
    height: 16,
    boxShadow: 'inset 0 0 0 1px rgba(16,22,26,.2), inset 0 -1px 0 rgba(16,22,26,.1)',
    backgroundColor: '#cf2338',
    backgroundImage: 'linear-gradient(180deg,hsla(0,0%,100%,.8),hsla(0,0%,100%,0))',
    '.Mui-focusVisible &': {
        outline: '2px auto rgba(19,124,189,.6)',
        outlineOffset: 2,
    },
    'input:hover ~ &': {
        backgroundColor: '#cf2338',
    },
    'input:disabled ~ &': {
        boxShadow: 'none',
        background: 'rgba(206,217,224,.5)',
    },
}));

const BpCheckedIcon = styled(BpIcon)({
    backgroundColor: '#cf2338',
    backgroundImage: 'linear-gradient(180deg,hsla(0,0%,100%,.1),hsla(0,0%,100%,0))',
    '&:before': {
        display: 'block',
        width: 16,
        height: 16,
        backgroundImage: 'radial-gradient(#fff,#fff 28%,transparent 32%)',
        content: '""',
    },
    'input:hover ~ &': {
        backgroundColor: '#cf2338',
    },
});

// Inspired by blueprintjs
function BpRadio(props) {
    return (
        <Radio
            disableRipple
            color="default"
            checkedIcon={<BpCheckedIcon />}
            icon={<BpIcon />}
            {...props}
        />
    );
}

export default BpRadio