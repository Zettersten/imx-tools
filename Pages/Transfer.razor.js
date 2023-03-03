function getConfig() {
    let starkContractAddress = "0xa3AEe8BcE55BEeA1951EF834b99f3Ac60d1ABeeB";
    let tokenAddress = "0xac98d8d1bb27a94e79fbf49198210240688bb1ed";
    let publicApiUrl = "https://api.x.immutable.com/v1";
    let linkFrameUrl = "https://link.x.immutable.com";
    let isSandbox = false;

    if (location.href.includes('?beta=true')) {
        starkContractAddress = "0x7917eDb51ecD6CdB3F9854c3cc593F33de10c623";
        tokenAddress = "0x01a75d789ec47271d740205944d101c32ed1c87d";
        publicApiUrl = "https://api.sandbox.x.immutable.com/v1";
        linkFrameUrl = "https://link.sandbox.x.immutable.com";
        isSandbox = true;
    }

    console.log("isSandbox", isSandbox);

    return {
        starkContractAddress,
        tokenAddress,
        publicApiUrl,
        linkFrameUrl,
        isSandbox
    };
}

export async function init(walletAddress) {
    const client = await getClient();

    const assets = await client.getAssets({
        user: walletAddress,
        page_size: 200,
        order_by: "desc"
    });

    return assets.result;
}

export async function transfer(assetIds, toAddress) {
    const client = await getLink();
    const config = getConfig();

    const payload = assetIds.map(assetId => {
        return {
            type: imx.ERC721TokenType.ERC721, // Must be of type ERC721
            tokenId: assetId, // the token ID
            tokenAddress: config.tokenAddress, // the collection address / contract address this token belongs to
            toAddress: toAddress // the wallet address this token is being transferred to
        };
    });

    const assets = await client.batchNftTransfer(payload);
    return assets;
}

async function getClient() {

    const config = getConfig();

    return await imx.ImmutableXClient.build({
        publicApiUrl: config.publicApiUrl,
        starkContractAddress: config.starkContractAddress
    });
}

function getLink() {

    const config = getConfig();

    return new imx.Link(config.linkFrameUrl);
}
